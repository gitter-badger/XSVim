﻿
namespace XSVim.Tests
open NUnit.Framework

[<TestFixture>]
module ``Movement tests`` =
    [<Test>]
    let ``Move to next word``() =
        assertText "aa$a bbb" "w" "aaa b$bb"

    [<Test>]
    let ``Move to next word on next line``() =
        assertText "aa$a\nbbb" "w" "aaa\nb$bb"

    [<Test>]
    let ``Moves to EOF when there is no next word``() =
        assertText "aa$aa" "w" "aaaa$"

    [<Test>]
    let ``Move to word end``() =
        assertText "aa$a bbb" "e" "aaa$ bbb"

    [<Test>]
    let ``Move to end of line``() =
        assertText "aa$a aaa\nbbb" "$" "aaa aaa$\nbbb"

    [<Test>]
    let ``Move to end of document``() =
        assertText "aa$aaaa\nbbbbbb" "G" "aaaaaa\nb$bbbbb"

    [<Test>]
    let ``Move to start of document``() =
        assertText "aaaaaa\nbb$bbbb" "gg" "a$aaaaa\nbbbbbb"

    [<Test>]
    let ``Move to line 2``() =
        assertText "a$aaaaa\nbbbbbb" "2gg" "aaaaaa\nb$bbbbb"

    [<Test>]
    let ``Move to line 3``() =
        assertText "a$aaaaa\nbbbbbb\ncccccc\ndddddd" "3G" "aaaaaa\nbbbbbb\nc$ccccc\ndddddd"

    [<Test>]
    let ``Move down to desired column``() =
        assertText "12345$6\n123\n123456" "jj" "123456\n123\n12345$6"

    [<Test>]
    let ``Move down to last column``() =
        assertText "12345$6\n123\n123456" "j" "123456\n123$\n123456"

    [<Test>]
    let ``Move across then down``() =
        assertText "1$2\n12\n" "lj" "12\n12$\n"

    [<Test>]
    let ``Move ten right``() =
        assertText "a$bcdefghijkl" "10l" "abcdefghijk$l"

    [<Test>]
    let ``Does not move right past delimiter``() =
        assertText "a$b\n" "ll" "ab$\n"