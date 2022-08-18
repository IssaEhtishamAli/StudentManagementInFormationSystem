using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class UserProfileRepositriy : IUserProfileRepositriy
    {
        private readonly ApplicationDbContext _context;
        public UserProfileRepositriy(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<object> GetProfile()
        {
            try
            {
                var result = (
                    from _usrp in _context.user_profile
                    join _user in _context.users on _usrp.user_id equals _user.id
                    join _gender in _context.gender on _usrp.gender_id equals _gender.id
                    join _degree in _context.degree on _usrp.degree_id equals _degree.id
                    join _section in _context.section on _usrp.section_id equals _section.id
                    join _country in _context.country on _usrp.country_id equals _country.id
                    join _city in _context.cities on _usrp.city_id equals _city.id
                    join _language in _context.language on _usrp.language_id equals _language.id
                    select new
                    {
                        id = _usrp.id,
                        user_id = _usrp.user_id,
                        user_name = _user.user_name,
                        gender_id = _usrp.gender_id,
                        gender_type = _gender.gender_type,
                        degree_id = _usrp.degree_id,
                        degree_title = _degree.degree_title,
                        section_id = _usrp.section_id,
                        country_id = _usrp.country_id,
                        section_name = _section.section_name,
                        name = _country.name,
                        city_id = _usrp.city_id,
                        city = _city.city,
                        first_name = _usrp.first_name,
                        last_name = _usrp.last_name,
                        cnic_no = _usrp.cnic_no,
                        permanent_address = _usrp.permanent_address,
                        resedential_address = _usrp.resedential_address,
                        zip_code = _usrp.zip_code,
                        contact_no = _usrp.contact_no,
                        date_of_birth = _usrp.date_of_birth,
                        language_id = _language.id,
                        language_name = _language.language_name
                    }
                    ).Distinct().ToList();
                if(result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
                }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public async Task<object> GteProfileById(int Id)
        {
            try
            {
                var result = (
                    from _usrp in _context.user_profile
                    join _user in _context.users on _usrp.user_id equals _user.id
                    join _gender in _context.gender on _usrp.gender_id equals _gender.id
                    join _degree in _context.degree on _usrp.degree_id equals _degree.id
                    join _section in _context.section on _usrp.section_id equals _section.id
                    join _country in _context.country on _usrp.country_id equals _country.id
                    join _city in _context.cities on _usrp.city_id equals _city.id
                    join _language in _context.language on _usrp.language_id equals _language.id
                    where _usrp.user_id==Id
                    select new
                    {
                        id = _usrp.id,
                        user_id = _usrp.user_id,
                        user_name = _user.user_name,
                        gender_id = _usrp.gender_id,
                        gender_type = _gender.gender_type,
                        degree_id = _usrp.degree_id,
                        degree_title = _degree.degree_title,
                        section_id = _usrp.section_id,
                        section_name = _section.section_name,
                        country_id = _usrp.country_id,
                        name = _country.name,
                        city_id = _usrp.city_id,
                        city = _city.city,
                        first_name = _usrp.first_name,
                        last_name = _usrp.last_name,
                        cnic_no = _usrp.cnic_no,
                        permanent_address = _usrp.permanent_address,
                        resedential_address = _usrp.resedential_address,
                        zip_code = _usrp.zip_code,
                        contact_no = _usrp.contact_no,
                        date_of_birth = _usrp.date_of_birth,
                        language_id = _language.id,
                        language_name = _language.language_name
                    }
                    ).FirstOrDefault();
                if (result  != null)
                {
                    return  result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public async Task<object> AddProfile(userprofile urp)
        {
            try
            {
                var _getProfile = _context.user_profile.Where(a => a.user_id == urp.user_id).FirstOrDefaultAsync();
                if (_getProfile == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "This user is already exist",
                        result = _getProfile
                    };
                    return (modl);
                }
                else
                {
                    await _context.user_profile.AddAsync(urp);
                    await _context.SaveChangesAsync();
                }
                return "User added sucessfully";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            }
        public async Task<object> UpdateProfile(userprofile urp)
        {
            try
            {
                var result = await _context.user_profile.FirstOrDefaultAsync(a => a.id == urp.id);
                if(result != null)
                {
                    result.user_id = urp.user_id;
                    result.gender_id = urp.gender_id;
                    result.degree_id = urp.degree_id;
                    result.section_id = urp.section_id;
                    result.country_id = urp.country_id;
                    result.city_id = urp.city_id;
                    result.zip_code = urp.zip_code;
                    result.date_of_birth = urp.date_of_birth;
                    result.language_id = urp.language_id;
                    result.first_name = urp.first_name;
                    result.last_name = urp.last_name;
                    result.contact_no = urp.contact_no;
                    result.cnic_no = urp.cnic_no;
                    result.resedential_address = urp.resedential_address;
                    result.permanent_address = urp.permanent_address;
                    await _context.SaveChangesAsync();
                    return "user profile updated sucess fully";
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteProfile(int Id)
        {
            try
            {
                var result = await _context.user_profile.Where(a => a.id == Id).FirstOrDefaultAsync();
                if (result  != null)
                {
                    _context.user_profile.Remove(result);
                    await _context.SaveChangesAsync();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
