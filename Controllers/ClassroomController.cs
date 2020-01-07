using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassroomConnect.Web.Models;
using ClassroomConnect.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ClassroomConnect.Core.DataContext;
using Microsoft.Extensions.Logging;
using ClassroomConnect.Web.Helpers;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using ClassroomConnect.Core.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using ClassroomConnect.Web.Models.ViewModels;
using System.Net;

namespace ClassroomConnect.Web.Controllers
{
    public class ClassroomController : Controller
    {       
        private readonly ILogger<ClassroomController> _logger;
        private readonly IMapper _mapper;
        public ClassroomController( ILogger<ClassroomController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<ClassroomVM> classrooms = JsonConvert.DeserializeObject<List<ClassroomVM>>(Api.GetApiRequest("GetClassrooms"));            

            return View(classrooms);
        }

        [Authorize]
        public IActionResult Classroom(string classroomId)
        {
            var classroomVM = JsonConvert.DeserializeObject<ClassroomVM>(Api.GetApiRequest("GetClassroomDetails", classroomId));

           
            return View(classroomVM);
        }

        [Authorize]
        public IActionResult StudentList(string classId)           
        {
            var guid = new Guid(classId);
            var classroomVM = JsonConvert.DeserializeObject<ClassroomVM>(Api.GetApiRequest("GetClassroomDetails", classId));
            return PartialView("_StudentList", classroomVM);
        }

        [Authorize]
        public List<GuardianVM> GuardianSearch(string searchString)
        {
            List<GuardianVM> guardians = null;

            var apiResponse =  Helpers.Api.GetApiRequest("SearchGuardian", searchString);

            guardians = JsonConvert.DeserializeObject<List<GuardianVM>>(apiResponse);

            return guardians;
        }

        [Authorize]
        public IActionResult NewFamilyRecord()
        {
            var response = Helpers.Api.PostApiRequest("CreateFamily");

            var familyId =  response.Replace("\"", "");

            return RedirectToAction("NewGuardianRecord", "Classroom", new { familyId = familyId });
        }

        [Authorize]
        public IActionResult NewChildRecord(string familyId)
        {
            Guid guid = new Guid(familyId);

            var er = new EnrollmentRecordVM();

            FamilyDetailVM family = JsonConvert.DeserializeObject<FamilyDetailVM>(Helpers.Api.GetApiRequest("GetFamilyDetail", familyId));

            if(family != null)
            {
                er.Child.FamilyId = guid;
                GuardianVM primGuardian = _mapper.Map<GuardianVM>(family.Guardians.Where(i => i.IsPrimaryGuardian).FirstOrDefault());

                er.PrimaryGuardian = primGuardian;

                GuardianVM secGuardian = _mapper.Map<GuardianVM>(family.Guardians.Where(i => !i.IsPrimaryGuardian).FirstOrDefault());

                if (secGuardian != null)
                    er.SecondaryGuardian = secGuardian;
            }

            return PartialView("_Enrollment_Child", er);
        }

        [Authorize]
        [HttpPost]
        public IActionResult NewChildRecord(EnrollmentRecordVM ervm)
        {
            if (ervm.ContactList.Count < 1)
            {
                ervm.ContactList.Add(new ContactVM() { FamilyId = ervm.Child.FamilyId });
            }

            Helpers.Api.PostApiRequest("CreateChild", ervm.Child);            

            //Cache values from database
            CacheManager.Set($"EnrollmentRecord.{ervm.Child.ChildId}", ervm, 15);

            return PartialView("_Enrollment_Contact", ervm);

        }

        [Authorize]
        public IActionResult NewGuardianRecord(string familyId)
        {
            Guid guid = new Guid(familyId);

            var er = new EnrollmentRecordVM();

            er.PrimaryGuardian.FamilyId = guid;
            er.PrimaryGuardian.IsPrimaryGuardian = true;
            er.SecondaryGuardian.FamilyId = guid;

            return PartialView("_Enrollment_Guardian", er);
        }

        [Authorize]
        [HttpPost]
        public IActionResult NewGuardianRecord(EnrollmentRecordVM ervm)
        {
            
            Helpers.Api.PostApiRequest("CreateGuardian", ervm.PrimaryGuardian);

            Helpers.Api.PostApiRequest("CreateGuardian", ervm.SecondaryGuardian);

            ervm.Child.FamilyId = ervm.PrimaryGuardian.FamilyId;

            //Cache values from database
            CacheManager.Set($"FamilyRecord.{ervm.PrimaryGuardian.FamilyId}", ervm, 15);

            return PartialView("_Enrollment_Child", ervm);

        }

        //[Authorize]
        //public IActionResult NewEnrollmentRecord(Guid classId, Guid familyId = new Guid())
        //{
        //    //var newEnrollmentRecord = new EnrollmentRecordVM();
        //    //var classroom = _context.Classroom.Where(c => c.ClassroomId == classId).FirstOrDefault();
        //    //var guidIsEmpty = familyId == Guid.Empty;
        //    //ChildVM child = new ChildVM();
        //    //if (!guidIsEmpty)
        //    //{
        //    //    child = new ChildVM() { FamilyId = familyId };                
        //    //}
        //    //newEnrollmentRecord.Child = child;
        //    //newEnrollmentRecord.Child.ClassroomId = classId;

        //    //return PartialView("_EnrollmentRecord", newEnrollmentRecord);
        //}

        [Authorize]
        public IActionResult EnrollmentRecord(string id)
        {
            var enrollmentRecord = Api.GetApiRequest("GetEnrollmentRecord", id);

            EnrollmentRecordVM ervm = JsonConvert.DeserializeObject<EnrollmentRecordVM>(enrollmentRecord);

            //if(ervm.PrimaryGuardian.Phones.Count < 1)
            //{
            //    ervm.PrimaryGuardian.Phones.Add(new PhoneVM());
            //}

            //if (ervm.PrimaryGuardian.Addresses.Count < 1)
            //{
            //    ervm.PrimaryGuardian.Addresses.Add(new AddressVM());
            //}

            //if (ervm.SecondaryGuardian.Phones.Count < 1)
            //{
            //    ervm.SecondaryGuardian.Phones.Add(new PhoneVM());
            //}

            //if (ervm.SecondaryGuardian.Addresses.Count < 1)
            //{
            //    ervm.SecondaryGuardian.Addresses.Add(new AddressVM());
            //}

            return PartialView("_EnrollmentRecord", ervm);
        }

        //[Authorize]
        //[HttpPost]
        //public string UpdateEnrollment(EnrollmentRecordVM ervm)
        //{
        //    AjaxReturnModel ajaxReturn = null;
        //    if (ModelState.IsValid)
        //    {
        //        ajaxReturn = Helpers.EnrollmentManager.UpdateEnrollmentRecord(ervm);
        //    }

        //    return JsonConvert.SerializeObject(ajaxReturn);
        //}

        [Authorize]
        [HttpPut]
        public string UpdateChild(EnrollmentRecordVM er)
        {
            ChildVM response = null;
            AjaxReturnModel ajaxReturn = null;
            if (ModelState.IsValid)
            {
                response = JsonConvert.DeserializeObject<ChildVM>(Api.PutApiRequest("UpdateChild", er.Child));
            }

            if (response != null )
            {
                ajaxReturn = new AjaxReturnModel() { ReturnObject = response, Status = 1, Message = $"Successfully Updated record for {er.Child.FirstName} {er.Child.LastName}" };
            }
            else
            {
                ajaxReturn = new AjaxReturnModel() { ReturnObject = response, Status = 0, Message = $"Unable to update record for: {er.Child.FirstName} {er.Child.LastName}" };
            }

            return JsonConvert.SerializeObject(ajaxReturn);
        }

        [Authorize]
        [HttpPut]
        public string UpdateContacts(EnrollmentRecordVM er)
        {
            List<ContactVM> response = null;
            AjaxReturnModel ajaxReturn = null;
            if (ModelState.IsValid)
            {                
                response = JsonConvert.DeserializeObject<List<ContactVM>>(Api.PutApiRequest("UpdateContacts", er.ContactList));
            }

            if (response != null)
            {
                ajaxReturn = new AjaxReturnModel() { ReturnObject = response, Status = 1, Message = $"Successfully Updated contact records for {er.Child.FirstName} {er.Child.LastName}" };
            }
            else
            {
                ajaxReturn = new AjaxReturnModel() { ReturnObject = response, Status = 0, Message = $"Unable to update contact records for: {er.Child.FirstName} {er.Child.LastName}" };
            }

            return JsonConvert.SerializeObject(ajaxReturn);
        }

        //[Authorize]
        //[HttpPost]
        //public string UpdateGuardian(GuardianVM guardian)
        //{
        //    bool result = false;
        //    AjaxReturnModel ajaxReturn = null;
        //    if (ModelState.IsValid)
        //    {
        //        result = Helpers.EnrollmentManager.UpdateGuardianRecord(guardian, _context);
        //    }

        //    if (result)
        //    {
        //        ajaxReturn = new AjaxReturnModel() { ReturnObject = result, Message = $"Successfully Updated record for: {guardian.FirstName} {guardian.LastName}" };
        //    }
        //    else
        //    {
        //        ajaxReturn = new AjaxReturnModel() { ReturnObject = result, Message = $"Unable to update record for: {guardian.FirstName} {guardian.LastName}" };
        //    }

        //    return JsonConvert.SerializeObject(ajaxReturn);
        //}



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [RequestSizeLimit(1_074_790_400)]
        [DisableRequestSizeLimit]
        public string UploadPhoto(String Base64, int x, int y, int w, int h, int rotate, string childName, bool touch, string imageType = "png")
        {
            string fileName = string.Format("{0}_{1}.{2}", childName, DateTime.Now.ToString("ddMMyyHHmmss"), imageType);
            string dirPath = @"C:\\Users\lconner\source\repos\ClassroomConnect.Web\ClassroomConnect.Web\wwwroot\images\profiles\";
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            FileInfo file = directory.GetFiles("*" + childName + "*").FirstOrDefault();
            if (file != null && System.IO.File.Exists(file.ToString()))
                System.IO.File.Delete(file.ToString());

            string filePath = dirPath + fileName;

            Regex reg = new Regex("^data:image/[^;]*;base64,?");
            string base64String = reg.Replace(Base64, "");
            byte[] bytes = Convert.FromBase64String(base64String);

            string targetPath = string.Format("~/../../images/profiles/{0}", fileName);

            Size size = new Size(400, 400);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (image = System.Drawing.Image.FromStream(ms))
                {
                    Bitmap bmpImage = new Bitmap(image);

                    Image srcImage = bmpImage; 

                    Image croppedImg = CropToCircle(srcImage, Color.Transparent);

                    croppedImg.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    croppedImg.Dispose();
                }
            }

            return targetPath;
        }


        public static Image CropToCircle(Image srcImage, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
            Graphics g = Graphics.FromImage(dstImage);
            using (Brush br = new SolidBrush(backGround))
            {
                g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, dstImage.Width, dstImage.Height);
            g.SetClip(path);
            g.DrawImage(srcImage, 0, 0);

            return dstImage;
        }

        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
    }
}
