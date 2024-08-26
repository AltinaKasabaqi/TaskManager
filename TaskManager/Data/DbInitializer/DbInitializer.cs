//using TaskManager.Data.Entities;

//namespace TaskManager.Data.DbInitializer
//{
//    public class DbInitializer : IDbInitializer
//    {
//        private readonly AppDbContext _db;

//        public DbInitializer(AppDbContext db)
//        {
//            _db = db;
//        }


//        public void Initialize()
//        {
//            _db.Database.EnsureCreated();

//            SeedLists();
//        }

//        private void SeedLists()
//        {
//            if (_db.Lists.Any())
//            {
//                return;
//            }

//            var lists = new List<List>
//            {
//                new List { ListName = "New" },
//                new List { ListName = "Active" },
//                new List { ListName = "Review" },
//                new List { ListName = "To Test" },
//                new List { ListName = "Testing" },
//                new List { ListName = "Completed" },
//            };


//            _db.Lists.AddRange(lists);
//            _db.SaveChanges();
//        }
//    }
//}
