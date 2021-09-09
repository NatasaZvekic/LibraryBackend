using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public RentalRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Rental> GetAllRentals(Boolean completed)
        {
            if (completed == true)
            {
                List<RentalWithDetails> result = RawSqlQuery("SELECT RentalID, r.BookID, BookName, r.DeliveryID, DeliveryCompanyName, r.UserID, Name, UserLastName,  r.EmployeeID, EmployeeName, EmployeeLastName, RentalDate FROM Rentals r INNER JOIN Books b on r.BookID = b.BookID INNER JOIN DeliveryCompany d on d.DeliveryID = r.DeliveryID INNER JOIN Employee e on e.EmployeeID = r.EmployeeID INNER JOIN Users u on u.UserID = r.UserID where r.DeliveryID != 'e69f696d-a5eb-4502-85cb-52b1ac548de1' ",

                x => new RentalWithDetails
                {
                    RentalID = (Guid)x[0],
                    BookID = (Guid)x[1],
                    BookName = (string)x[2],
                    DeliveryID = (Guid)x[3],
                    DeliveryCompanyName = (String)x[4],
                    UserID = (Guid)x[5],
                    UserName = (String)x[6] + " " + (String)x[7],
                    EmployeeID = (Guid)x[8],
                    EmployeeName = (String)x[9] + " " + (String)x[10],
                    RentalDate = ((DateTime)x[11]).Date

                }); ; ; ;

                return mapper.Map<List<Rental>>(result);
            }
            else
            {
                List<RentalWithDetails> result = RawSqlQuery("SELECT RentalID, r.BookID, BookName, r.DeliveryID, DeliveryCompanyName, r.UserID, Name, UserLastName,  r.EmployeeID, EmployeeName, EmployeeLastName, RentalDate FROM Rentals r INNER JOIN Books b on r.BookID = b.BookID INNER JOIN DeliveryCompany d on d.DeliveryID = r.DeliveryID INNER JOIN Employee e on e.EmployeeID = r.EmployeeID INNER JOIN Users u on u.UserID = r.UserID where r.DeliveryID = 'e69f696d-a5eb-4502-85cb-52b1ac548de1'",
                                     x => new RentalWithDetails
                     {
                         RentalID = (Guid)x[0],
                         BookID = (Guid)x[1],
                         BookName = (string)x[2],
                         DeliveryID = (Guid)x[3],
                         DeliveryCompanyName = (String)x[4],
                         UserID = (Guid)x[5],
                         UserName = (String)x[6] + " " + (String)x[7],
                         EmployeeID = (Guid)x[8],
                         EmployeeName = (String)x[9] + " " + (String)x[10],
                         RentalDate = ((DateTime)x[11]).Date

                     }); ; ; ;

                return mapper.Map<List<Rental>>(result);
            }
           // return mapper.Map<List<Rental>>(context.Rentals.ToList());
        }

        public List<Rental> GetRentalByID(Guid userID)
        {
            String user_id = userID.ToString();
            List<RentalWithDetails> result = RawSqlQuery("SELECT RentalID, r.BookID, BookName, r.DeliveryID, DeliveryCompanyName, r.UserID, UserName, UserLastName,  r.EmployeeID, EmployeeName, EmployeeLastName, RentalDate FROM Rentals r INNER JOIN Books b on r.BookID = b.BookID INNER JOIN DeliveryCompany d on d.DeliveryID = r.DeliveryID INNER JOIN Employee e on e.EmployeeID = r.EmployeeID INNER JOIN Users u on u.UserID = r.UserID where r.UserID =" + "'" + user_id + " '" ,
                                     x => new RentalWithDetails
                                     {
                                         RentalID = (Guid)x[0],
                                         BookID = (Guid)x[1],
                                         BookName = (string)x[2],
                                         DeliveryID = (Guid)x[3],
                                         DeliveryCompanyName = (String)x[4],
                                         UserID = (Guid)x[5],
                                         UserName = (String)x[6] + " " + (String)x[7],
                                         EmployeeID = (Guid)x[8],
                                         EmployeeName = (String)x[9] + " " + (String)x[10],
                                         RentalDate = ((DateTime)x[11]).Date

                                     }); ; ; ;

            return mapper.Map<List<Rental>>(result);
        }
        public Guid AddNewRental(Rental rental)
        {
            var newRental = mapper.Map<RentalDB>(rental);
            var guid = Guid.NewGuid();
            newRental.RentalID = guid;
            newRental.RentalDate = DateTime.Today;
            context.Rentals.Add(newRental);
            context.SaveChanges();

            return guid;
        }

        public void UpdateRental(Rental rental, Guid rentalID)
        {
            var oldRental = context.Rentals.FirstOrDefault(e => e.RentalID == rentalID);

            if (oldRental == null)
            {
                throw new Exception("not found");
            }

            oldRental.BookID = rental.BookID;
            oldRental.DeliveryID = rental.DeliveryID;
            oldRental.EmployeeID = rental.EmployeeID;
            oldRental.UserID = rental.UserID;
            oldRental.RentalDate = rental.RentalDate;
            oldRental.RentalDate = DateTime.Today;

            context.SaveChanges();
        }
        public bool DeleteRental(Guid rentalID)
        {
            var rental = context.Rentals.FirstOrDefault(e => e.RentalID == rentalID);
            if (rental == null)
            {
                return false;
            }

            context.Rentals.Remove(rental);
            context.SaveChanges();
            return true;
        }

        public List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
        }

     

    }
}
