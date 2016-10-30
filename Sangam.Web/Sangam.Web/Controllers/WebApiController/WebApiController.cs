using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sangam.Core.Model;
using Sangam.Data;

namespace Sangam.Web.Controllers.WebApiController
{
    public class WebApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        public void CreateWebAPIRouteQuantity(Core.Model.RouteQuality res)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            rep.CreateRouteQuality(res);
        }
        public void CreateWebAPIWeighmentIn(Core.Model.WeighmentModel res)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            rep.WeighmentInEntry(res);
        }
        [HttpGet]
        public List<Core.Model.WeighmentModel> GetWeighmentIn(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            return rep.GetPlayers(page, limit, sortBy, direction, searchString);
        }
        public List<Core.Model.WeighmentModel> GetWeighmentInforEdit(int? wId)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            return rep.GetWeighmentInForEdit(wId);
        }
        public void DeleteItems(int itemId)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            rep.DeleteItems(itemId);
        }
        public TankerQualityModel GetTankerQualityDetails(string rSTNo, string rCellType)
        {
            SangamRepository rep = new SangamRepository();
            return rep.GetTankerQualityDetails(rSTNo, rCellType);
        }
        public WeighmentModel GetTankerDetails(string rSTNo)
        {
            SangamRepository rep = new SangamRepository();
            return rep.GetTankerDetails(rSTNo);
        }
        public void CreateWebAPITankerDataSaveUpdate(Core.Model.TankerQualityModel res)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            rep.TankerDataSaveUpdate(res);
        }
        public void InsertVendor(Core.Model.VendorModel res)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            rep.InsertVendor(res);
        }
        public void InsertVendorTanker(Core.Model.VendorTankerModel res)
        {
            Data.SangamRepository rep = new Data.SangamRepository();
            rep.InsertVendorTanker(res);
        }
        public VendorModel GetAllVendorDetails()
        {
            SangamRepository rep = new SangamRepository();
            return rep.GetAllVendorDetails();
        }
    }

}