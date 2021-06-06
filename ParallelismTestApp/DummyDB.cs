using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelismTestApp
{
    class DummyDB
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

        public DummyDB() { } // end ctor

        public List<DummyDB> GenerateDummyDBObjs(int numOfObjs)
        {
            var dummies = new List<DummyDB>();

            for (int i = 1; i <= numOfObjs; i++)
            {
                var dummy = new DummyDB 
                { 
                    Id = $"{i}", 
                    FirstName = $"FirstName{i}", 
                    LastName = $"LastName{i}", 
                    Address=$"Address{i}",
                    MobileNumber = $"555-{i}"
                };

                dummies.Add(dummy);
            }

            return dummies;

        } // end public List<DummyDB> GenerateDummyDBObjs(int numOfObjs)

    } // end class DummyDB

} // end namespace ParallelismTestApp
