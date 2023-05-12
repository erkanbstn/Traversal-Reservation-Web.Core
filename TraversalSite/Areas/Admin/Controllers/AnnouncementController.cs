using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.AnnouncementDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.YouCanList());
            return View(values);
        }
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDto announcementAddDto)
        {
            if (ModelState.IsValid)
            {
                _announcementService.YouCanInsert(new Announcement()
                {
                    Content = announcementAddDto.Content,
                    Title = announcementAddDto.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())

                });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
