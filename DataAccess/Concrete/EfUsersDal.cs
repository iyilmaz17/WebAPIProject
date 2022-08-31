using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUsersDal : EfEntityRepository<User, WebAPIContext>, IUserDal
    {


        //void IUserDal.KullanıcıKayıt(TestKullanıcıTamKayıt testKullanıcıTamKayıt)
        //{
        //    using (WebAPIContext context = new WebAPIContext())
        //    {
        //        var kayıt = from u in context.Users
        //                    join a in context.Addresses
        //                    on u.UserId equals a.AddressId
        //                    select new TestKullanıcıTamKayıt
        //                    {
        //                        Name1 = u.Name,
        //                        Surname1 = u.Surname,
        //                        UserId1 = u.UserId,
        //                        BirthDate1 = u.BirthDate,
        //                        Email1 = u.Email,
        //                        Phone1 = u.Phone,
        //                        ProfilImage1 = u.ProfilImage,
        //                        Password1 = u.Password,
        //                        AddressText1 = a.AddressText,
        //                        AUserId1 = a.UserId,
        //                        CityId1 = a.CityId,
        //                        DistrictId1 = a.DistrictId,
        //                    };
        //        var addedEntity = context.Entry(kayıt);
        //        addedEntity.State = EntityState.Added;
        //        context.SaveChanges();
        //    }

        //}

    }
}
