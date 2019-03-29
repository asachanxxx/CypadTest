using Cypad.Model;
using Cypad.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cypad.Service.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : ApiController
    {

        GenericRepository<Customer> CusRepo;
        GenericRepository<Product> proRepo;

        public CustomerController()
        {
            CusRepo = new GenericRepository<Customer>("customers");
            //CusRepo.GetAll();
            //proRepo.GetAll();
        }

        [Route("SaveCustomer")]
        [HttpPost]
        public HttpResponseMessage SaveCustomer(Customer obj)
        {
            try
            {
                return Request.CreateResponse<int>(CusRepo.Insert(obj));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public HttpResponseMessage UpdateCustomer(Customer obj)
        {
            try
            {
                return Request.CreateResponse<bool>(CusRepo.Update(obj));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("DeleteCustomer")]
        [HttpPost]
        public HttpResponseMessage DeleteCustomer(int CustomerId)
        {
            try
            {

                return Request.CreateResponse<bool>(CusRepo.Delete(CustomerId));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("FindAllCustomers")]
        [HttpGet]
        public HttpResponseMessage FindAllCustomers()
        {
            try
            {
                return Request.CreateResponse<IEnumerable<Customer>>(CusRepo.GetAll());

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



        [Route("FindCustomer")]
        [HttpGet]
        public HttpResponseMessage FindCustomers(int Id)
        {
            try
            {
                return Request.CreateResponse<Customer>(CusRepo.GetById(Id));

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
