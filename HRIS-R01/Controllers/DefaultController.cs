﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using HRIS_R01.Models.Common;
using HRIS_R01.Models;
using HRIS_R01.Models.Session;
using HRIS_R01.Controllers.Shared;
using System.Text;
using System.DirectoryServices;
using HRIS_R01.Models.Session;
//using HRIS_R01.Models.Employee;
using System.Web.Routing;
using System.Threading.Tasks;
using System.Data;
using HRIS_R01.Models;
using System.Data.Entity;


namespace HRIS_R01.Controllers
{
    public class DefaultController : ApplicationController<LogOnModel>
    {
        string Msg = "Login Initialize...";
        //UserEntities dbUser = new UserEntities();
        //EmployeeEntities dbEmp = new EmployeeEntities();
        private MasterHRISEntities db = new MasterHRISEntities();


        // GET: Default
        public ActionResult Index()
        {
            // return this.RedirectToAction("LogOn", "Default");
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult temp1()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LogOn(LogOnModel model, string returnUrl)
        {
            
            if (ModelState.IsValid)
            {
                emp_user user = await db.emp_user.Where(b => b.IDVMAIL == model.UserName).FirstOrDefaultAsync();

                //db.emp_user user = await db.emp_user.Where(b => b.IDVMAIL == model.UserName).FirstOrDefaultAsync();
                //leave leave = await db.leaves.FindAsync(id);
                if (user == null)
                {
                    ViewBag.Msg = "The user name provided is incorrect, please register";
                    return View(model);
                } else
                {
                    /*Set model to session*/
                    SetLogOnSessionModel(model);
                    /*Shows the session*/
                    LogOnModel sessionModel = GetLogOnSessionModel();
                    try
                    {
                        //if (true == AuthenticateUser(model.UserName, model.Password, out Msg))
                        if (true == await AuthenticateLocal(model))
                        {
                            if ( true == SetCredential(model) )
                            {
                                Msg = "Login OK";
                                ViewBag.Msg = Msg;
                                return this.RedirectToAction("Index", "vEmployee");
                            } else
                            {
                                Msg = "Unable to Set User Caching, Contact Web Administrator";
                                ViewBag.Msg = Msg;
                                return View(model);
                            }


                            
                            //Response.Redirect("default.aspx");// Authenticated user redirects to default.aspx
                        }

                    }
                    catch (Exception e)
                    {
                        //this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
                        Msg = "error.";
                        ViewBag.Msg = Msg;
                        //return this.RedirectToAction("Logon", "Default");
                        return View(model);
                    }
                }

                
            }
           //return this.RedirectToAction("Logon", "Default");
            return View(model);
        }

       
        
        public bool SetCredential(LogOnModel model)
        {
            SetUserSession(model);
            return true;
        }

        public async Task<bool> AuthenticateLocal(LogOnModel model)
        {
            var getUser = await db.emp_user.FirstOrDefaultAsync(b => b.IDVMAIL == model.UserName || b.IDVMAILPASSWORD == model.Password);
            
            if (getUser == null)
            {
                ViewBag.Msg = "The password provided is incorrect";
                return false;
            } else
            {
                model.IDV = getUser.IDV.HasValue ? getUser.IDV.Value: 0;
                return true;
            }
        }

        public bool AuthenticateUser(string username, string password, out string Errmsg)
        {
            /*
            
            string domain = "hollit";
            string LdapPath = "LDAP://hlad01:389/ou=Users,dc=Hollit";
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    ViewBag.Msg = "Auth Error";
                    return false;
                }
                // Update the new path to the user in the directory
                LdapPath = result.Path;
                string _filterAttribute = (String)result.Properties["cn"][0];
                ViewBag.Msg = "Auth OK";
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                ViewBag.Msg = Errmsg;
                return false;
                throw new Exception("Error authenticating user." + ex.Message);
            }
            
            */
            Errmsg = "";
            ViewBag.Msg = "NULL";
            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://localhost:389/ou=Users,dc=hris,dc=com");
                Object obj = de.NativeObject;
                System.Diagnostics.Debug.WriteLine(obj.ToString());
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.SearchScope = SearchScope.Subtree;
                ds.Filter = "(uid= " + username + ")";
                System.Diagnostics.Debug.WriteLine(username);
                SearchResultCollection results = ds.FindAll();
                if (results.Count > 0)
                {
                    ViewBag.Msg = "OK";
                    return true;
                }
            } catch (Exception ex)
            {
                ViewBag.Msg =  ex.Message;
                System.Diagnostics.Debug.WriteLine("==========================================================");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace.ToString());
                System.Diagnostics.Debug.WriteLine("==========================================================");
                System.Diagnostics.Debug.WriteLine(ex.Source.ToString());
                System.Diagnostics.Debug.WriteLine("==========================================================");
                System.Diagnostics.Debug.WriteLine(ex.InnerException);
                System.Diagnostics.Debug.WriteLine("==========================================================");
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine("==========================================================");
                return false;
            }


            return true;
        }


        public ActionResult LogOff()
        {
            /*distroy current session and go to login page*/
            AbandonSession();
            return RedirectToAction("Index", "LogOn");
        }
    }
}