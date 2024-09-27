using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
           return View("~/Views/User/Index.cshtml", userlist); // Ensure the method returns a view with the user list
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
           return View("~/Views/User/Details.cshtml", userlist[id]); // Ensure the method returns a view with the user details
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View("~/Views/User/Create.cshtml"); // Ensure the method returns a view to create a new user
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
          return View("~/Views/User/Create.cshtml", user); // Ensure the method returns a view to create a new user
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
           return View("~/Views/User/Edit.cshtml", userlist[id]); // Ensure the method returns a view to edit a user}
        }
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            // Implement the Edit method (POST) here

            return View("~/Views/User/Edit.cshtml", user); // Ensure the method returns a view to edit a user
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method (GET) here
            return View("~/Views/User/Delete.cshtml", userlist[id]); // Ensure the method returns a view to delete a user
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            // Implement the Delete method (POST) here
            return View("~/Views/User/Delete.cshtml", userlist[id]); // Ensure the method returns a view to delete a user
        }
}
