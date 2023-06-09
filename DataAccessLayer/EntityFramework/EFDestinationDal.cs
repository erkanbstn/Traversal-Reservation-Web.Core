﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public List<Destination> GetDestinationsBy3()
        {
            using (var c = new  Context())
            {
                return c.Destinations.Take(3).ToList();
            }
        }
        public void SetTrueStatus(int id)
        {
            using (var c = new Context())
            {
                var dest = c.Destinations.Find(id);
                dest.Status = true;
                c.SaveChanges();
            }
        }
        public void SetFalseStatus(int id)
        {
            using (var c = new Context())
            {
                var dest = c.Destinations.Find(id);
                dest.Status = false;
                c.SaveChanges();
            }
        }
    }
}
