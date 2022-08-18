using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using student_management.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.Repositries
{
    public class QualificationRepositriy : IQualificationRepositriy
    {
        private readonly ApplicationDbContext _Context;
        public QualificationRepositriy(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<object> GetQualification()
        {
            try
            {
                var result = (
                    from _qafs in _Context.qualifications
                    join _usr in _Context.users on _qafs.user_id equals _usr.id
                    select new
                    {
                        id = _qafs.id,
                        user_id = _qafs.user_id,
                        institute_name = _qafs.institute_name,
                        major_subjects = _qafs.major_subjects,
                        obtained_marks = _qafs.obtained_marks,
                        total_marks = _qafs.total_marks
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

        public async Task<object> GetQualificationById(int Id)
        {
            try
            {
                var result = (
                    from _qafs in _Context.qualifications
                    join _usr in _Context.users on _qafs.user_id equals _usr.id
                    select new
                    {
                        id = _qafs.id,
                        user_id = _qafs.user_id,
                        institute_name = _qafs.institute_name,
                        major_subjects = _qafs.major_subjects,
                        total_marks = _qafs.total_marks,
                        obtained_marks = _qafs.obtained_marks
                    }
                    ).FirstOrDefault();
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
        public async Task<object> AddQualification(qualification qaf)
        {
            try
            {
                var _data = await _Context.qualifications.Where(a => a.user_id == qaf.user_id).FirstOrDefaultAsync();
                if (_data == null)
                {
                    var model = new
                    {
                        statusCode = 409,
                        message = "This user is already exist",
                        result = _data
                    };
                    return (model);
                }
                else
                {
                    await _Context.qualifications.AddAsync(qaf);
                    await _Context.SaveChangesAsync();
                }
                return "user qualifications details added sucessfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UpdateQualification(qualification qaf)
        {
            try
            {
                var result = await _Context.qualifications.FirstOrDefaultAsync(a => a.user_id == qaf.user_id);
                if(result != null)
                {
                    result.user_id = qaf.user_id;
                    result.institute_name = qaf.institute_name;
                    result.major_subjects = qaf.major_subjects;
                    result.obtained_marks = qaf.obtained_marks;
                    result.total_marks = qaf.total_marks;
                    await _Context.SaveChangesAsync();
                    return "user qualification details updated sucessfully";
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
        public async Task<object> DeleteQualification(int Id)
        {
            try
            {
                var result = await _Context.qualifications.FirstOrDefaultAsync(a => a.user_id == Id);
                if(result != null)
                {
                    _Context.qualifications.Remove(result);
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
