using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.ConnectParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.DisconnectParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileCopyParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileDeleteParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileMoveParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileRenameParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileShowParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeGotoParse;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeListParse;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Chain
{
    public Chain()
    {
        IFileShowArgumentChain fileShowArgumentChain = new FileShowPathChain();
        IConnectArgumentChain connectArgumentChain = new ConnectAddressChain();
        connectArgumentChain.AddNextChain(new ParseConnectArgument(new ConnectModeChain()));
        IFileCopyArgumentChain fileCopyArgumentChain = new FileCopySourcePath();
        fileCopyArgumentChain.AddNextChain(new FileCopyDestinationPath());
        IFileMoveArgumentChain fileMoveArgumentChain = new FileMoveSourcePathChain();
        fileMoveArgumentChain.AddNextChain(new FileMoveDestinationPathChain());
        IFileRenameArgumentChain fileRenameArgumentChain = new FileRenamePathChain();
        fileRenameArgumentChain.AddNextChain(new FileRenameNameChain());
        CommandChain connectChain = new ConnectCommandChain(connectArgumentChain);
        CommandChain disconnectChain = new DisconnectCommandChain(new ParseDisconnectArguments(new CheckDisconnectArguments()));
        CommandChain fileCopyChain = new FileCopyChain(fileCopyArgumentChain, new ParseFileCopyArgument(null));
        CommandChain fileMoveChain = new FileMoveChain(fileMoveArgumentChain, new ParseFileMoveArgument(null));
        CommandChain fileShowChain = new FileShowChain(fileShowArgumentChain, new ParseFileShowArgument(new FileShowModeChain()));
        CommandChain fileRenameChain = new FileRenameChain(fileRenameArgumentChain, new ParseFileRenameArgument(null));
        CommandChain fileDeleteChain = new FileDeleteChain(new FileDeletePathChain(), new ParseFileDeleteArgument(null));
        CommandChain treeGotoChain = new TreeGotoChain(new TreeGotoPathChain(), new ParseTreeGotoArgument(null));
        CommandChain treeListChain = new TreeListChain(new ParseTreeListArgument(new DepthChain()));
        fileCopyChain.AddNextChain(fileMoveChain);
        fileDeleteChain.AddNextChain(fileCopyChain);
        fileRenameChain.AddNextChain(fileDeleteChain);
        fileShowChain.AddNextChain(fileRenameChain);
        CommandChain fileChain = new FileChain(fileShowChain);
        treeGotoChain.AddNextChain(treeListChain);
        CommandChain treeChain = new TreeChain(treeGotoChain);

        treeChain.AddNextChain(fileChain);
        disconnectChain.AddNextChain(treeChain);
        connectChain.AddNextChain(disconnectChain);
        CommandChain = connectChain;
    }

    public ICommandChain CommandChain { get; }

    public void Handle(Request request)
    {
        CommandChain.Handle(request);
    }
}