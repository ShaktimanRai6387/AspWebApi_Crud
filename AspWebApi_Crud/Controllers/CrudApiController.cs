using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc.Razor;
using System.Web.UI.WebControls;
using AspWebApi_Crud.Models;

namespace AspWebApi_Crud.Controllers
{
    public class CrudApiController : ApiController
    {
        Web_Api_Crud_DbEntities4 db = new Web_Api_Crud_DbEntities4();

        [HttpGet]
        //DATA READE
        public IHttpActionResult GetEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        [HttpGet]
        //DATA READE
        public IHttpActionResult GetEmployeesById(int id)
        {
            var emp = db.Employees.Where(Model => Model.Id == id).FirstOrDefault();
            return Ok(emp);

            //List<Employee> list = db.Employees.ToList();
            //return Ok(list);
        }

        //POST VALUE AND DATA CREATE
        [HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        //PUT VALUE AND DATA UPDATE
        [HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            db.Entry(e).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //var emp = db.Employees.Where(Model => Model.Id == e.Id).FirstOrDefault();
            //if (emp != null)
            //{
            //    emp.Id = e.Id;
            //    emp.Name = e.Name;
            //    emp.Gender = e.Gender;
            //    emp.Age = e.Age;
            //    emp.Designation = e.Designation;
            //    emp.Salary = e.Salary;

            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }

        //DELETE DATA
        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Employees.Where(Model => Model.Id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
