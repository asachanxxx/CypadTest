using Cypad.Model;
using Cypad.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cypad.Service.Controllers
{
    [RoutePrefix("CustomerAsync")]
    public class CustomerAsyncController : ApiController
    {
        GenericRepositoryAsync<Customer> CusRepo;
        

        public CustomerAsyncController()
        {
            
            CusRepo = new GenericRepositoryAsync<Customer>("customers");
        }

        [Route("SaveCustomer")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveCustomer(Customer obj)
        {
            try
            {
                return Request.CreateResponse<int>(await CusRepo.Insert(obj));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateCustomer(Customer obj)
        {
            try
            {
                return Request.CreateResponse<bool>(await CusRepo.Update(obj));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("DeleteCustomer")]
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteCustomer(int CustomerId)
        {
            try
            {

                return Request.CreateResponse<bool>(await CusRepo.Delete(CustomerId));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("FindAllCustomers")]
        [HttpGet]
        public async Task<HttpResponseMessage> FindAllCustomers()
        {
            try
            {
                return Request.CreateResponse<IEnumerable<Customer>>(await CusRepo.GetAll());

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("FindCustomer")]
        [HttpGet]
        public async Task<HttpResponseMessage> FindCustomer(int Id)
        {
            try
            {
                return Request.CreateResponse<Customer>(await CusRepo.GetById(Id));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


    }
}
