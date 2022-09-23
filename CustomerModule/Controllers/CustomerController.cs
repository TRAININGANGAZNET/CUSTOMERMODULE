using CustomerModule.DAL;
using CustomerModule.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CustomerModule.Model.Request;

namespace CustomerModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGetDataReadersAsync _getDataReadersAsync;
        private readonly IConfiguration _configuration;
        private readonly string myConnectionString;

        public CustomerController(IConfiguration configuration,IGetDataReadersAsync getDataReadersAsync)
        {
            _configuration = configuration;
            _getDataReadersAsync = getDataReadersAsync;
            myConnectionString = _configuration["ConnectionStrings:DBConnectionString"];
        }

        [Route("createCustomer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<UserregistrationResponse> createCustomer([FromBody] CreateCustomer createCustomer)
        {
            UserregistrationResponse listres = new UserregistrationResponse();
            var Saveuserdata = _configuration["Queries:InsertUserRegistrationData"];
            try
            {
                listres = await Task.Run(() => _getDataReadersAsync.Saveaccount<UserregistrationResponse, CreateCustomer>(Saveuserdata, createCustomer, myConnectionString));
                if(listres.id != null)
                {
                    listres.Responses = _configuration["Responses:AccountSucess"];
                }
                else
                {
                    listres.Responses = _configuration["Responses:FailMessage"];
                }
                return listres;
            }
            catch(Exception ex)
            {
                return listres;
            }
           

        }

        [Route("getCustomerDetails")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> getCustomerDetails([FromBody] GetcustDetails getcustDetails)
        {
            CustomerResponse custresp = new CustomerResponse();
            try
            {
                var getcustomerdata = _configuration["Queries:GetCustomerDetails"];
                var Custresp = await Task.Run(() => _getDataReadersAsync.GetChildDataAsync<CustomerResponse, dynamic>(getcustomerdata, getcustDetails, myConnectionString));
                if(Custresp.Count()!=0)
                {
                    custresp.Responses = _configuration["Responses:SuccessCustDetails"];
                    return Ok( custresp);
                }
                else
                {
                    custresp.Responses = _configuration["Responses:FailedCustDetails"];
                }
                return Ok(custresp);

            }
            catch (Exception ex)
            {
                custresp.Responses = _configuration["Responses:FailedCustDetails"];
                return Ok(custresp);
            }
        }

       

    }
}
