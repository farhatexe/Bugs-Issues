namespace ProjectTasks.Presentation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class ResourceController : Controller
    {
        public ActionResult Index(IEnumerable<string> res)
        {
            try
            {
                var javascriptBuilder = new StringBuilder();
                javascriptBuilder.Append("{");

                javascriptBuilder.Append(res.Select(resourceName =>
                {
                    var builder = new StringBuilder();

                    var resourceType = Type.GetType("Resources." + resourceName);

                    builder.AppendFormat("\"{0}\":", resourceName);
                    builder.Append("{");

                    builder.Append(resourceType
                        .GetProperties(BindingFlags.Static | BindingFlags.NonPublic)
                        .Where(x => x.PropertyType == typeof(String))
                        .Select(x => String.Format("\"{0}\": \"{1}\"", x.Name, x.GetValue(null)))
                        .Aggregate((a, b) => a + "," + b));

                    builder.Append("}");
                    return builder.ToString();

                }).Aggregate((a, b) => a + ", " + b));

                javascriptBuilder.Append("}");

                return Content(javascriptBuilder.ToString(), "application/json");
            }
            catch (Exception error)
            {
                Response.StatusCode = 500;
                return Content(error.ToString(), "application/text");
            }
        }
    }
}