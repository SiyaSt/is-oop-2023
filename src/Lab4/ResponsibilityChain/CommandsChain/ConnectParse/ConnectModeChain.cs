using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.ConnectParse;

public class ConnectModeChain : ConnectArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, ConnectModel.Builder builder)
   {
       if (request.Command.Current != "-m")
       {
           return NextChain is not null ? NextChain.Handle(request, builder) :
               new ArgumentsResultTypes.ErrorResult("Error command flag");
       }

       request.Command.MoveNext();
       builder.WithMode(request.Command.Current);

       return new ArgumentsResultTypes.SuccessResult();
   }
}