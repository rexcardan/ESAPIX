using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESAPIX.Fakes
{
    //public class Faker
    //{
    //    public static FakeScriptContext GenerateFakeScriptContext()
    //    {
    //        var sc = new FakeScriptContext();
    //        sc.Patient = Activator.CreateInstance<VMS.TPS.Common.Model.API.Patient>();
    //        //-------------//PATIENT//----------------//
    //        var patient = Fake<Patient>(0, p =>
    //        {
    //            p.FirstName = "Faky";
    //            p.MiddleName = "F";
    //            p.LastName = "Fakerson";
    //            p.DateOfBirth = DateTime.Now;
    //        });
    //        //-------------//PLAN SETUPS//----------------//
    //        var setups = FakeList<PlanSetup>(3, ps =>
    //        {
    //            ps.CreationUserName = "masterCardan";
    //            ps.CreationDateTime = DateTime.Now;
    //        });
    //         //-------------//PLAN SUMS//----------------//
    //        var sums = FakeList<PlanSum>(2, ps =>
    //        {
    //            ps.CreationDateTime = DateTime.Now;
    //        });
    //          //-------------//STRUCTURE SET//----------------//
    //        var structureSet = Fake<StructureSet>(0,ss=>{
    //            ss.Structures = FakeList<Structure>(10);
    //        });
    //        //-------------//COURSE//----------------//
    //        sc.Course = Fake<Course>(1, c =>
    //        {
    //            c.CompletedByUserName = "completedUser";
    //            c.CompletedDateTime = DateTime.Now;
    //            c.PlanSetups = setups;
    //            c.PlanSums = sums;
    //        });

    //        sc.Patient = patient;
    //        sc.PlanSetup = setups.First();
    //        sc.PlansInScope = setups;
    //        sc.PlanSumsInScope = sums;
    //        sc.StructureSet = structureSet;
    //        sc.CurrentUser = Fake<User>();

    //        return sc;
    //    }

    //    /// <summary>
    //    /// This method automatically fills out ApiDataObject values to some defaults
    //    /// </summary>
    //    /// <typeparam name="T">the class type to fake</typeparam>
    //    /// <param name="instanceNumber">the number to be used in filling out default values</param>
    //    /// <param name="propertySetter">extra parameters that need to be faked</param>
    //    /// <returns>an instance of the faked class</returns>
    //    public static T Fake<T>(int instanceNumber = 0, GetVMSAction<T> propertySetter = null) where T : ApiDataObject
    //    {
    //        var type = typeof(T);
    //        var instance = Activator.CreateInstance<T>();
    //        instance.Comment = string.Format("{0} Comment {1}", type.Name, instanceNumber);
    //        instance.HistoryDateTime = DateTime.Now;
    //        instance.HistoryUserName = "fakeUser";
    //        instance.Id = string.Format("{0} {1} Id", type.Name, instanceNumber);
    //        instance.Name = string.Format("{0} {1} Name", type.Name, instanceNumber);

    //        //Set extra properties
    //        if (propertySetter != null)
    //        {
    //            propertySetter(instance);
    //        }
    //        return instance;
    //    }

    //    public static IEnumerable<T> FakeList<T>(int numberToFake = 1, GetVMSAction<T> instancePropertySetter = null) where T : ApiDataObject
    //    {
    //        List<T> list = new List<T>();
    //        for (int i = 0; i < numberToFake; i++)
    //        {
    //            list.Add(Fake<T>(i,instancePropertySetter));
    //        }
    //        return list;
    //    }
    //}
}
