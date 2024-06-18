using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADOCRUDopration.Models;

namespace ADOCRUDopration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration

        DBOpration db = new DBOpration();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetState()
        {
            List<StateModel> state = new List<StateModel>();
            DataSet ds = db.GetStateData();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                state.Add(new StateModel
                {
                    StateId = Convert.ToInt32(dr["StateId"]),
                    StateName = ( dr["StateName"].ToString())
                });
            }
            return Json(state);
        }
        public JsonResult GetCity(int StateId)
        {
            List<CityModel> States = new List<CityModel>();
            DataSet ds = db.GetCityData(StateId);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                States.Add(new CityModel
                {
                    CityId = Convert.ToInt32(dr["CityId"]),
                    CityName = dr["CityName"].ToString()
                });
            }
            return Json(States);
        }

        public JsonResult SaveReg (RegistrationModel model)
        {
            int result = db.SaveReg(model);
            return Json(result);
        }

        public JsonResult GetReg()
        {
            List<RegistrationModel> reg = db.RegData();//model method name
            return Json(reg);
        }
        public JsonResult Delete(int Id)
        {
            return Json(db.DeleteReg(Id));//model method name DeletReg
        }

        public JsonResult EditReg(int Id)
        {
            List<RegistrationModel> reglist = new List<RegistrationModel>();
            DataSet ds = new DataSet();
            ds = db.EditReg(Id);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                reglist.Add(new RegistrationModel()
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    MobileNo = dr["MobileNo"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = Convert.ToInt32(dr["City"].ToString()),
                    State = Convert.ToInt32(dr["State"].ToString()),
                    Pincode = dr["Pincode"].ToString(),
                    Email = dr["EmailId"].ToString(),
                    PassWord = dr["PassWord"].ToString(),
                    Hobbies = dr["Hobbies"].ToString(),
                });
            }
            return Json(reglist);
        }
    }
}