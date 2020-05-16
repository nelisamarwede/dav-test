using DAV.Domain.EF.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DAV.Domain.EF.Commands
{
    public class ImageCommands : CommandBase
    {
        public ImageCommands(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public DAV.Domain.Entities.Image AddImage(DAV.Domain.Entities.Image image)
        {
            image.name = "";

            _context.Add(image);
            _context.SaveChanges();

            return image;
        }

        public bool UpdateImage(DAV.Domain.Entities.Image image)
        {
            _context.Attach(image).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Update(image);

            _context.SaveChanges();
            return true;
        }

        public void DeleteImage(DAV.Domain.Entities.Image image)
        {
            _context.Attach(image).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
    }
}
