using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

PersonManager personManager = new PersonManager(new EfPersonDal());
