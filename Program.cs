using financial_pyramid.Helpers;
using financial_pyramid.Model;
using financial_pyramid.Module;

namespace financial_pyramid;

public class Program
{
    public static void Main(string[] args)
    {
        var pyramid   = DeserializationHelper.DeserializeFromFileXML<Pyramid>(args[0]);
        var transfers = DeserializationHelper.DeserializeFromFileXML<Transfers>(args[1]);

        var companyMemberModule = new CompanyMemberModule(pyramid);

        companyMemberModule.ExecuteTransfers(transfers.ListOfTransfers);

        companyMemberModule.WriteAllMembersOfCompany();
    }
}