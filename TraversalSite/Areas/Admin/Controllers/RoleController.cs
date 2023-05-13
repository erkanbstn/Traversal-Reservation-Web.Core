using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.AnnouncementDto;
using DtoLayer.Dtos.AppRoleDto;
using DtoLayer.Dtos.AppUserDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<RoleListDto>>(_roleManager.Roles.ToList());
            return View(values);
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddDto roleAddDto)
        {
            AppRole appRole = new AppRole()
            {
                Name = roleAddDto.Name,
                NormalizedName = roleAddDto.Name.ToUpper()
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleManager.DeleteAsync(_roleManager.Roles.FirstOrDefault(b => b.Id == id));
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(b => b.Id == id);
            RoleUpdateDto roleUpdateDto = new RoleUpdateDto()
            {
                Name = value.Name,
                NormalizedName = value.Name.ToUpper()
            };
            return View(roleUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateDto roleUpdateDto)
        {
            var value = _roleManager.Roles.FirstOrDefault(b => b.Id == roleUpdateDto.Id);
            value.Name = roleUpdateDto.Name;
            value.NormalizedName = roleUpdateDto.Name.ToUpper();
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UsersRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(b => b.Id == id);
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            TempData["userId"] = user.Id;
            List<RoleByUserListDto> RoleByUserListDto = new List<RoleByUserListDto>();

            foreach (var role in roles)
            {
                RoleByUserListDto roleByUserList = new RoleByUserListDto()
                {
                    RoleName = role.Name,
                    RoleId = role.Id,
                    RoleExist = userRoles.Contains(role.Name)
                };
                RoleByUserListDto.Add(roleByUserList);
            }
            return View(RoleByUserListDto);
        }
        [HttpPost]
        public async Task<IActionResult> UsersRole(List<RoleByUserListDto> roleByUserListDtos)
        {
            var userId = (int)TempData["userId"];
            var user = _userManager.Users.FirstOrDefault(b => b.Id == userId);
            foreach (var item in roleByUserListDtos)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
