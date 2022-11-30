namespace Shared

module InputReader =
    let ReadInputText (inputfile: string) =
        System.IO.File.ReadAllText(inputfile)

    let ReadInputLines (inputfile: string) =
        System.IO.File.ReadAllLines(inputfile)