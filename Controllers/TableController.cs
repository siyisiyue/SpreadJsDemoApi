using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace SpreadJsDemoApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    [EnableCors("any")]
    public class TableController : Controller
    {
        private readonly SpreadContext _context;
        private readonly IMapper _mapper;
        private readonly EFHelper _helper;
        public IConfiguration Configuration { get; }
        public TableController(SpreadContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _helper = new EFHelper(_context);
            Configuration = configuration;
        }

        /// <summary>
        /// 根据表类型反射表属性
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        [HttpGet]
        public ObjectResult GetTableKeys(string tableName)
        {
            var defaultNameSpace = Configuration.GetSection("defaultNamespace").Value;
            TableHead th = new TableHead();
            List<SelectDto> keys = new List<SelectDto>();
            var relation = _context.Relation.Where(x => x.TableName == tableName).FirstOrDefault();
            if (relation == null)
            {
                return Ok(new { code = 1, msg = "表名不存在，请检查对应表" });
            }
            var typeName = (relation.DtoNameSpace.IsNullOrEmpty() ? defaultNameSpace : relation.DtoNameSpace) +"."+ relation.TableDtoName;
            GetObjKeys(typeName, keys);
            return Ok(new { code = 0, msg = "", data = keys });
        }
        /// <summary>
        /// 通过字符串获取类名
        /// </summary>
        /// <param name="TypeName"></param>
        /// <returns></returns>
        private Type GetType(string TypeName)
        {
            return Type.GetType(TypeName);
        }

        /// <summary>
        /// 获取所有的table表名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ObjectResult GetAllTableName()
        {
            var lst = _context.Relation.Select(x => x.TableName).ToList();
            return Ok(new { code = 0, msg = "", data = lst });
        }

        /// <summary>
        /// 通用方法：通过表实例返回对应的key用于绑定
        /// </summary>
        /// <param name="TypeName"></param>
        /// <param name="keys"></param>
        private void GetObjKeys(string TypeName, List<SelectDto> keys)
        {
            Type t = Type.GetType(TypeName);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                var name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
               // var value = pi.GetValue(obj, null);//用pi.GetValue获得值
                var v = (DescriptionAttribute[])pi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var descriptionName = v.Length > 0 ? v[0].Description : "";
                if (descriptionName != "")
                {
                    keys.Add(new SelectDto() { label = descriptionName, value = name });
                }
               // var type = value?.GetType() ?? typeof(object);//获得属性的类型
            }
        }
        /// <summary>
        /// 保存配置的坐标
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PostionTemp>> SavePostion(List<PostionTemp> list)
        {
            foreach (var p in list)
            {
                var entity = await _context.PostionTemp.Where(x => x.Row == p.Row && x.Col == p.Col && x.TableName == p.TableName).FirstOrDefaultAsync();
                if (entity != null)
                {
                    entity.Row = p.Row;
                    entity.Col = p.Col;
                    entity.FieldName = p.FieldName;
                    entity.RowCount = p.RowCount;
                    entity.ColCount = p.ColCount;
                    entity.Type = p.Type;
                    _context.PostionTemp.Update(entity);
                }
                else
                {
                    await _context.PostionTemp.AddAsync(p);
                }

            }

            _context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// 根据表名获取所有坐标点
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [HttpGet]
        public ObjectResult GetAllPostion(string TableName)
        {

            return Ok(GetPostion(TableName));
        }
        /// <summary>
        /// 根据表名获取所有的坐标
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private List<PostionTemp> GetPostion(string TableName)
        {
            var lst = _context.PostionTemp.Where(x => x.TableName == TableName).ToList();
            return lst;
        }
        /// <summary>
        /// 通过ID删除坐标点
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DeletePostion(EntityDto dto)
        {
            var entity = await _context.PostionTemp.FindAsync(dto.Id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.PostionTemp.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// 通用查询接口
        /// </summary>
        /// <param name="id">表单ID</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        [HttpGet]
        public object GetData(int id, string tableName)
        {
            var defaultNameSpace = Configuration.GetSection("defaultNamespace").Value;
            var rel = _context.Relation.Where(x => x.TableName == tableName).FirstOrDefault();
            if (rel==null)
            {
                return Ok(new { code = 1, msg = "表单不存在" });
            }
            GetTableDataDto entity = new GetTableDataDto() { Id = id, TableName = tableName, InstanceCount =rel.InstanceCount };
            var dataTypeName = (rel.TableNamespace.IsNullOrEmpty() ? defaultNameSpace : rel.TableNamespace) + "." + rel.TableDtoDataName;
            var dtoTypeName = (rel.DtoNameSpace.IsNullOrEmpty() ? defaultNameSpace : rel.DtoNameSpace) + "." + rel.TableDtoName;
            Type t = Type.GetType(dtoTypeName);
            Type t2 = Type.GetType(dataTypeName);
            Type[] typeArgs = { t, t2 };
            var result = this.GetType().GetMethod("GetTableDto").MakeGenericMethod(typeArgs).Invoke(this, new object[] { entity });
            return result;
        }


        /// <summary>
        /// 通用查询方法
        /// </summary>
        /// <typeparam name="T">dto类</typeparam>
        /// <typeparam name="F">dto类下的Data类</typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ObjectResult GetTableDto<T, F>(GetTableDataDto dto) where T : class, BaseData<T, F>, new() where F : class, BaseParent, new()
        {
            TableHead th = _context.TableHead.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (th == null)
            {
                T entity = new T() { TableName = dto.TableName };

                List<F> lst = new List<F>();
                for (int i = 0; i < dto.InstanceCount; i++)
                {
                    F s = new F();
                    lst.Add(s);
                }
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
            else
            {
                var entity = _mapper.Map<T>(th);
                var lst = _helper.Quyery<F>(x => x.TableHeadId == th.Id).ToList();
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
        }
        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ObjectResult GetAllData()
        {
            var rel = _context.Relation.Select(x=>x.TableName).ToList();
            var lst = _context.TableHead.Select(x => new { x.Id, x.TableName, x.Name }).ToList();
            List<object> data = new List<object>();
            foreach (var item in rel)
            {
                data.Add(new { type = item, list = lst.Where(x => x.TableName == item).ToList() });
            }

            return Ok(new { code = 0, msg = "", data = data });
        }

        /// <summary>
        /// 通用保存接口
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(TableSaveDto dto)
        {
            try
            {
                var defaultNameSpace = Configuration.GetSection("defaultNamespace").Value;
                var rel = _context.Relation.Where(x => x.TableName == dto.tableName).FirstOrDefault();
                if (rel == null)
                {
                    return Ok(new { code = 1, msg = "表单不存在" });
                }
                var dataTypeName = (rel.TableNamespace.IsNullOrEmpty() ? defaultNameSpace : rel.TableNamespace) + "." + rel.TableDtoDataName;
                var dtoTypeName = (rel.DtoNameSpace.IsNullOrEmpty() ? defaultNameSpace : rel.DtoNameSpace) + "." + rel.TableDtoName;
                Type t = Type.GetType(dtoTypeName);
                Type t2 = Type.GetType(dataTypeName);
                Type[] typeArgs = { t, t2 };
                this.GetType().GetMethod("SaveTable").MakeGenericMethod(typeArgs).Invoke(this, new object[] { dto.Data });
                return Ok(new { code = 0, msg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { code = 1, msg = ex.Message });
            }

        }

        /// <summary>
        /// 通用保存逻辑业务
        /// </summary>
        /// <typeparam name="T">表dto</typeparam>
        /// <typeparam name="F">表dto里的数据类型</typeparam>
        /// <param name="json">表dto的json字符串</param>
        public void SaveTable<T, F>(string json) where T : class, BaseData<T, F> where F : class, BaseParent
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            var th = _mapper.Map<TableHead>(obj);
            var result = SaveObject<TableHead>(th);
            List<F> lst = obj.Data;
            foreach (var item in lst)
            {
                item.TableHeadId = result.Id;
                SaveObject<F>(item);
            }
        }
        /// <summary>
        /// 通用保存方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T SaveObject<T>(T obj) where T : class, BaseEntity
        {
            if (obj.Id > 0)
            {
                _context.Entry<T>(obj).State = EntityState.Modified;
            }
            else
            {
                _context.Entry<T>(obj).State = EntityState.Added;
            }

            _context.SaveChanges();
            return obj;
        }




    }

}
