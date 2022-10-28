using Employee_Mangement_system.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Employee_Mangement_system.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Employee_List()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086")
            };
            List<EmployeeDetailsMvc>? employee = new List<EmployeeDetailsMvc>();
            HttpResponseMessage res = await client.GetAsync("api/Values/GET");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<List<EmployeeDetailsMvc>>(result);
            }
            return View(employee);

        }

        public async Task<IActionResult> Post()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086")
            };

            List<Designationmvc>? destemp = new List<Designationmvc>();
            HttpResponseMessage res = await client.GetAsync("api/Designation/get");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                destemp = JsonConvert.DeserializeObject<List<Designationmvc>>(result);
                ViewData["destemp"] = destemp;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDetailsMvc emp1)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086")
            };

            List<Designationmvc>? destemp = new List<Designationmvc>();
            HttpResponseMessage res = await client.GetAsync("api/Designation/get");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                destemp = JsonConvert.DeserializeObject<List<Designationmvc>>(result);
                ViewData["destemp"] = destemp;
            }

            var postTask = client.PostAsJsonAsync("api/Values/post", emp1);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Employee_List");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string Username)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086")
            };
            await client.DeleteAsync($"api/Values/delete/{Username}");
            return RedirectToAction("Employee_List");

        }
        //[HttptGet]
        public async Task<IActionResult> Edit(string Username)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086")
            };

            List<Designationmvc>? destemp = new List<Designationmvc>();
            HttpResponseMessage res = await client.GetAsync("api/Designation/get");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                destemp = JsonConvert.DeserializeObject<List<Designationmvc>>(result);
                ViewData["destemp"] = destemp;
            }

            TempClass employee = new TempClass();
            HttpResponseMessage res1 = await client.GetAsync($"api/Values/get/{Username}");
            if (res1.IsSuccessStatusCode)
            {
                var result = res1.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<TempClass>(result);
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TempClass temp)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7086");

            List<Designationmvc>? destemp = new List<Designationmvc>();
            HttpResponseMessage res = await client.GetAsync("api/Designation/get");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                destemp = JsonConvert.DeserializeObject<List<Designationmvc>>(result);
                ViewData["destemp"] = destemp;
            }

            HttpResponseMessage postTask = client.PostAsJsonAsync<TempClass>("api/Values/edit", temp).Result;
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Employee_List");
            }
            return View();
        }
        public ActionResult Designation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Designation(Designationmvc designation)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7086");
            var postTask = client.PostAsJsonAsync<Designationmvc>("api/Designation/designation", designation);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("dashboard");
            }
            return View();
        }
       

        public ActionResult Dashboard()
        {
            return View();
        }


    }
}

