using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialProject.Data;
using TutorialProject.Models;
using System;
using System.Threading.Tasks;

namespace TutorialProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SocialMediaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ **Create New Social Media Record**
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] social_links socialMedia)
        {
            if (socialMedia == null)
                return BadRequest(new { message = "Invalid data provided." });

            if (string.IsNullOrWhiteSpace(socialMedia.Facebook) || 
                string.IsNullOrWhiteSpace(socialMedia.Twitter) ||
                string.IsNullOrWhiteSpace(socialMedia.Linkedin) || 
                string.IsNullOrWhiteSpace(socialMedia.Email))
            {
                return BadRequest(new { message = "All fields are required." });
            }

            try
            {
                _context.social_links.Add(socialMedia);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Social Media details saved successfully!", data = socialMedia });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error saving social media record", error = ex.Message });
            }
        }

        // ✅ **Update Existing Social Media Record**
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] social_links updatedSocialMedia)
        {
            if (updatedSocialMedia == null)
                return BadRequest(new { message = "Invalid data provided." });

            var existingSocialMedia = await _context.social_links.FindAsync(id);
            if (existingSocialMedia == null)
                return NotFound(new { message = "Social Media record not found!" });

            try
            {
                // **Backup Existing Record Before Updating**
                var history = new social_links
                {
                    Facebook = existingSocialMedia.Facebook,
                    Twitter = existingSocialMedia.Twitter,
                    Linkedin = existingSocialMedia.Linkedin,
                    Email = existingSocialMedia.Email,
                };
                _context.social_links.Add(history);

                // **Update the Existing Record**
                existingSocialMedia.Facebook = updatedSocialMedia.Facebook;
                existingSocialMedia.Twitter = updatedSocialMedia.Twitter;
                existingSocialMedia.Linkedin = updatedSocialMedia.Linkedin;
                existingSocialMedia.Email = updatedSocialMedia.Email;

                await _context.SaveChangesAsync();
                return Ok(new { message = "Social Media details updated successfully!", data = existingSocialMedia });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating social media record", error = ex.Message });
            }
        }
    }
}
