using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class CommentController : Controller
    {
        // GET: Admin/Comment
        public ActionResult UnconfirmedComments()
        {
            TempData["Active"] = ActiveTempDataInfo.UnconfirmedComments;
            List<UrunYorum> unconfirmedComments = ContextDB.Connect.UrunYorumDal.GetUnconfirmedUrunYorumlar();
            return View(unconfirmedComments);
        }

        public ActionResult PastComments()
        {
            TempData["Active"] = ActiveTempDataInfo.PastComments;
            List<UrunYorum> confirmedComments = ContextDB.Connect.UrunYorumDal.GetConfirmedUrunYorumlar();
            return View(confirmedComments);
        }

        public ActionResult ConfirmComment(int commentId)
        {
            UrunYorum yorum = ContextDB.Connect.UrunYorumDal.GetById(commentId);
            yorum.OnayDurum = true;
            ContextDB.Connect.UrunYorumDal.AddOrUpdate(yorum);
            return RedirectToAction("UnconfirmedComments");
        }

        [HttpPost]
        public bool RejectComment(int id)
        {
            try
            {
                UrunYorum yorum = ContextDB.Connect.UrunYorumDal.GetById(id);
                ContextDB.Connect.UrunYorumDal.Remove(yorum);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}