using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public abstract class EntityController<MISAEntity> : ControllerBase
    {
        #region Declare Kết nối Dtbs 
        protected DbConnector _dbConnector;
        #endregion

        #region constructor khởi tạo hàm kn
        //hàm khởi tạo tên phải TRÙNG VS TÊN CLASS
        public EntityController()
        {
            _dbConnector = new DbConnector();
        }
        #endregion


        [HttpGet]
        public IActionResult Get()
        {
            DbConnector dbConnector = new DbConnector();
            //Dữ liệu từ database
            var customerGroups = _dbConnector.Get<MISAEntity>();
            //Trả dữ liệu cho Client:
            return Ok(customerGroups);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            //Dữ liệu từ database
            var customerGroups = _dbConnector.GetById<MISAEntity>(id);
            //Trả dữ liệu cho Client:
            return Ok(customerGroups);
        }

        
        //[HttpPost]
        //public IActionResult Post([FromBody] MISAEntity customerGroup)
        //{
        //    //Check trùng mã:
            
        //    var customerGroupid = customerGroup.CustomerGroupId;
        //    if (customerGroupid.ToString() == "")
        //        return BadRequest("Mã nhóm khách hàng không được phép để trống");
        //    //Video Rec 01-11-21 1 giờ 20                 <------------
        //    DynamicParameters dynamicParameters = new DynamicParameters();
        //    var properties = customerGroup.GetType().GetProperties();
        //    foreach (var property in properties)
        //    {
        //        var propertyName = property.Name;
        //        var propertyValue = property.GetValue(customerGroup);
        //        if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
        //        {
        //            propertyValue = propertyValue.ToString();
        //        }

        //        dynamicParameters.Add($"@{propertyName}", propertyValue);
        //    }


        //    //Dữ liệu vào database
        //    var customers = _dbConnection.Execute("Proc_InsertCustomerGroup", commandType: CommandType.StoredProcedure, param: dynamicParameters);
        //    return Ok(customerGroup);
        //}
    }
}

