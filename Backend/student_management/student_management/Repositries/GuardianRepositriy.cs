using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class GuardianRepositriy : IGuardianRepositriy
    {
        private readonly ApplicationDbContext _Context;
        public GuardianRepositriy (ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetGuardian()
        {
            try
            {
                var result = (
                    from _grn in _Context.guardians
                    join _usr in _Context.users on _grn.user_id equals _usr.id
                    select new
                    {
                        id=_grn.id,
                        user_id= _grn.user_id,
                        father_name=_grn.father_name,
                        father_contact_no=_grn.father_contact_no,
                        father_cnic_no = _grn.father_cnic_no,
                        father_occupation = _grn.father_occupation
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
        public async Task<object> GetGuardianById(int Id)
        {
            try
            {
                var result = (
                  from _grn in _Context.guardians
                  join _usr in _Context.users on _grn.user_id equals _usr.id
                  select new
                  {
                      id = _grn.id,
                      user_id = _grn.user_id,
                      father_name = _grn.father_name,
                      father_contact_no = _grn.father_contact_no,
                      father_cnic_no = _grn.father_cnic_no,
                      father_occupation = _grn.father_occupation
                  }
                  ).FirstOrDefault();
                if (result != null)
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
        public async Task<object> AddGuardian(guardian gdn)
        {
            try
            {
                var _getgrdn = await _Context.guardians.Where(a => a.user_id == gdn.user_id).FirstOrDefaultAsync();
                if (_getgrdn == null)
                {
                    var modl = new
                    {
                        statsuCode = 409,
                        message = "This user is already exist",
                        result = _getgrdn
                    };
                    return (modl);
                }
                else
                {
                    await _Context.guardians.AddAsync(gdn);
                    await _Context.SaveChangesAsync();
                }
                return "user  guardianv details added sucessfully";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
        
        public async Task<object> UpdateGuardian(guardian gdn)
        {
            try
            {
                var result = await _Context.guardians.FirstOrDefaultAsync(a => a.id == gdn.id);
                if (result != null)
                {
                    result.user_id = gdn.user_id;
                    result.father_name = gdn.father_name;
                    result.father_cnic_no = gdn.father_cnic_no;
                    result.father_contact_no = gdn.father_contact_no;
                    result.father_occupation = gdn.father_occupation;
                    await _Context.SaveChangesAsync();
                    return "Student guardian details updated sucessfully";
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
        public async Task<object> DeleteGuardian(int Id)
        {
            try
            {
                var result = await _Context.guardians.FirstOrDefaultAsync(a => a.id == Id);
                if (result != null)
                {
                    _Context.guardians.Remove(result);
                    await _Context.SaveChangesAsync();
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
