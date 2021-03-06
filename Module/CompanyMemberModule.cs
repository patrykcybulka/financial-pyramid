using financial_pyramid.Enum;
using financial_pyramid.Exceptions;
using financial_pyramid.Model;

namespace financial_pyramid.Module
{
    public class CompanyMemberModule
    {
        private const int permittedRange = 1000000;

        private readonly List<CompanyMember> companyMembers;

        public CompanyMemberModule(Pyramid pyramid)
        {
            companyMembers = convertToCompanyMemberList(pyramid.Participant);

            verifyCompanyMembers();
        }

        public void WriteAllMembersOfCompany()
        {
            foreach (var member in companyMembers)
            {
                Console.WriteLine("{0} {1} {2} {3}", member.Id, member.PyramidLevel, member.NumberOfSubordinatesWithoutSubordinates, member.Amount);
            }
        }

        public void ExecuteTransfers(IEnumerable<Transfer> transfers)
        {
            foreach (var transfer in transfers)
            {
                executeTransfer(transfer);
            }
        }

        private void executeTransfer(Transfer transfer)
        {
            if (transfer.Amount > permittedRange || transfer.Amount < 0)
            {
                throw new FinancialPyramidException(EErrorCode.InvalidAmount);
            }

            var amount = Convert.ToDouble(transfer.Amount);

            var companyMember = companyMembers.FirstOrDefault(c => c.Id == transfer.From);

            if (companyMember == null)
            {
                throw new FinancialPyramidException(EErrorCode.CompanyMemberNotExit);
            }

            var superiors = companyMembers.Where(c => companyMember.IdentifiersOfSuperiors.Contains(c.Id)).OrderBy(c => c.PyramidLevel);

            var numberOfSupervisors = superiors.Count();

            foreach (var supervisor in superiors)
            {
                if (numberOfSupervisors != 1)
                {
                    var amountAfterRound = Convert.ToInt32(Math.Floor(amount / 2));

                    supervisor.Amount += amountAfterRound;
                    amount -= amountAfterRound;
                }
                else
                {
                    supervisor.Amount += Convert.ToInt32(amount);
                    amount -= amount;
                }

                numberOfSupervisors--;
            }
        }

        private List<CompanyMember> convertToCompanyMemberList(Participant participant, int pyramidLevel = 0, HashSet<int> identifiersOfSuperiors = null)
        {
            var companyMembersList = new List<CompanyMember>();

            var numberOfSubordinatesWithoutSubordinates = 0;

            var superiorIds = new HashSet<int>();

            if (identifiersOfSuperiors != null)
            {
                foreach (var id in identifiersOfSuperiors)
                {
                    superiorIds.Add(id);
                }
            }

            foreach (var subordinate in participant.Subordinates)
            {
                superiorIds.Add(participant.Id);

                companyMembersList.AddRange(convertToCompanyMemberList(subordinate, pyramidLevel + 1, superiorIds));

                if (!subordinate.Subordinates.Any())
                {
                    numberOfSubordinatesWithoutSubordinates++;
                }
                else
                {
                    var companyMember = companyMembersList.FirstOrDefault(c => c.Id == subordinate.Id);

                    numberOfSubordinatesWithoutSubordinates += companyMember.NumberOfSubordinatesWithoutSubordinates;
                }
            }

            companyMembersList.Add(new CompanyMember
            {
                Id                                      = participant.Id,
                PyramidLevel                            = pyramidLevel,
                IdentifiersOfSuperiors                  = identifiersOfSuperiors == null ? new HashSet<int>() : identifiersOfSuperiors,
                NumberOfSubordinatesWithoutSubordinates = numberOfSubordinatesWithoutSubordinates
            });

            return companyMembersList.OrderBy(c => c.Id).ToList();
        }

        private void verifyCompanyMembers()
        {
            if (companyMembers.Exists(c => c.Id > permittedRange || c.Id < 0))
            {
                throw new FinancialPyramidException(EErrorCode.InvalidIdRange);
            }

            if (companyMembers.Exists(c => c.PyramidLevel > permittedRange || c.PyramidLevel < 0))
            {
                throw new FinancialPyramidException(EErrorCode.IncorrectPyramidLevelRange);
            }

            if (companyMembers.Exists(c => c.NumberOfSubordinatesWithoutSubordinates > permittedRange || c.NumberOfSubordinatesWithoutSubordinates < 0))
            {
                throw new FinancialPyramidException(EErrorCode.InvalidNumberOfSubordinatesWithNoSubordinates);
            }
        }
    }
}
