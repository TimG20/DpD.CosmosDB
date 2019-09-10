using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;

namespace DpD.CosmosDB.Controllers
{
    [RoutePrefix("api/Lessons")]
    public class LessonsController : ApiController
    {

        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetLessonsListAsync()
        {

            IEnumerable<Lesson> value = await DocumentDBRepository<Lesson>.GetItemsAsync();
            return value;
        }

        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetLessonsByMonthAsync(string month)
        {

            IEnumerable<Lesson> value = await DocumentDBRepository<Lesson>.GetItemsByMonthAsync(d => d.MonthDay.Contains(month), d => d.NumDayOfYear);
            return value;
        }

        [HttpGet]
        public async Task<Lesson> GetLessonAsync(string dayOfYear)
        {

            Lesson value = await DocumentDBRepository<Lesson>.GetSingleItemAsync(d => d.DayOfYear == dayOfYear);
            if (value == null)
            {
                return null;
            }
            return value;
        }

        [HttpPut]
        public async Task<Lesson> UpdateLesson(string id, [FromBody] Lesson Lesson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Lesson item = await DocumentDBRepository<Lesson>.GetSingleItemAsync(d => d.Id == id);
                    if (item == null)
                    {
                        return null;
                    }
                    Lesson.Id = item.Id;
                    await DocumentDBRepository<Lesson>.UpdateItemAsync(item.Id, Lesson);
                    return Lesson;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //[HttpPost]
        //public async Task<Lesson> CreateAsync([FromBody] Lesson Lesson)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await DocumentDBRepository<Lesson>.CreateItemAsync(Lesson);
        //        return Lesson;
        //    }
        //    return null;
        //}

        //public async Task<string> Delete(string uid)
        //{
        //    try
        //    {
        //        Lesson item = await DocumentDBRepository<Lesson>.GetSingleItemAsync(d => d.UId == uid);
        //        if (item == null)
        //        {
        //            return "Failed";
        //        }
        //        await DocumentDBRepository<Lesson>.DeleteItemAsync(item.Id);
        //        return "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}


    }
}