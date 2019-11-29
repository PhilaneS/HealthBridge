using HealthbridgeApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthbridgeApiHelper
{
    public interface IPatientRepository
    {
        IEnumerable<PatientDto> GetPatients();
        PatientDto GetPatientById(int? id);
        bool Register(PatientDto patientDto);

        object updatePatient(PatientDto dtoToUpdate);

        object DeletePatient(PatientDto dtoToDelete);
    }
}
