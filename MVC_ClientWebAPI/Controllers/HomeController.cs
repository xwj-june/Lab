﻿using MVC_ClientWebAPI.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using System.Linq;
//using System.Web;
using System.Web.Mvc;

namespace MVC_ClientWebAPI.Controllers
{
    public class HomeController : Controller
    {
        //Hosted web API REST Service base Url
        string Baseurl = "https://gender-api.com/en/api-docs/";
        public async Task<ActionResult> Index()
        {
            List<Employee> EmpInfo = new List<Employee>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employee/GetAllEmployees");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(EmpInfo);
            }
        }

        // GET: Home
        //public ActionResult Index()
        //{
        //    List<>

        //    return View();
        //}
    }
}