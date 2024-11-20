using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers{

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
          var existe = userlist.FirstOrDefault(u => u.Id == id);
          if(existe == null) {
                NotFound();
            }
           return View("~/Views/User/Details.cshtml", userlist[id]); // Ensure the method returns a view with the user details
        }

        public ActionResult Buscar()
        {
            return View("~/Views/User/Search.cshtml"); // Ensure the method returns a view to create a new user
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
            var existe = userlist.FirstOrDefault(u => u.Id == user.Id);
            if(existe == null) {
                user.Id = userlist.Count;
                userlist.Add(user);
            }
           
           return RedirectToAction("Index");
           //return View("~/Views/User/Index.cshtml", userlist); // Ensure the method returns a view to create a new user
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
                // Retrieve the user by ID from the user list
    var existingUser = userlist.FirstOrDefault(u => u.Id == id);
    // If the user is not found, return HttpNotFound
    if (existingUser == null)
    {
        return NotFound();
    }
           return View("~/Views/User/Edit.cshtml", userlist[id]); // Ensure the method returns a view to edit a user}
        }
 // POST: User/Edit/5
[HttpPost]
public ActionResult Edit(int id, User user)
{
    // Retrieve the user by ID from the user list
    var existingUser = userlist.FirstOrDefault(u => u.Id == id);
    // If the user is not found, return HttpNotFound
    if (existingUser == null)
    {
        return NotFound();
    }

    // Update the user's information with the data from the form submission
    if (ModelState.IsValid)
    {
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        
        // Save the changes (assuming userList is a database context or similar)
        // dbContext.SaveChanges(); // Uncomment if using a database context

        // Redirect to the Index action if successful
        return RedirectToAction("Index");
    }

    // If an error occurs, return the Edit view with validation errors
    return View("~/Views/User/Edit.cshtml", user);
}

// GET: User/Delete/5
public ActionResult Delete(int id)
{
    // Retrieve the user by ID from the user list
    var user = userlist.FirstOrDefault(u => u.Id == id);
    
    // If the user is not found, return HttpNotFound
    if (user == null)
    {
        return NotFound();
    }

    // Return the Delete view with the user to be deleted
    return View("~/Views/User/Delete.cshtml", user);
}

// POST: User/Delete/5
[HttpPost]
public ActionResult Delete(int id, IFormCollection collection)
{
    // Retrieve the user by ID from the user list
    var user = userlist.FirstOrDefault(u => u.Id == id);
    
    // If the user is not found, return HttpNotFound
    if (user == null)
    {
        return NotFound();
    }

    // Remove the user from the user list
    userlist.Remove(user);
    
    // Save the changes (assuming userList is a database context or similar)
    // dbContext.SaveChanges(); // Uncomment if using a database context

    // Redirect to the Index action if successful
    return RedirectToAction("Index");
}

// GET: User/Search
public ActionResult Search(string query)
{
    var results = userlist.Where(u => u.Name.Contains(query) || u.Email.Contains(query)).ToList();
    return View("~/Views/User/Search.cshtml", results);
}

}
}