namespace ProjectTasks.Presentation.ConsoleApp
{
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using ProjectTasks.Crosscuttings.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProjectTasks.Business.Domain.Entities;

    /// <summary>
    /// Quick test project in console application.
    /// </summary>
    class Program
    {
        private static IServices areaServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args">List of arguments.</param>
        static void Main(string[] args)
        {
            var root = areaServices.GetAllAreas().Where(a => a.ParentId == null).FirstOrDefault();
            areaServices.CreateArea(new Business.Domain.Entities.Area()
            {
                Label = "Area 1.1",
                ParentId = root.Id
            });
            areaServices.CreateArea(new Business.Domain.Entities.Area()
            {
                Label = "Area 1.2",
                ParentId = root.Id
            });
            areaServices.CreateArea(new Business.Domain.Entities.Area()
            {
                Label = "Area 1.3",
                ParentId = root.Id
            });

            List<Area> result = new List<Area>();
            var all = areaServices.GetAllAreas().Where(a => a.ParentId == null).ToList();
            all.Flatten(a => a.Children, ref result);
            
            result.ToList();
        }
    }
}
