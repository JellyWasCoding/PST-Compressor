# PST-Compressor
[![Build status](https://ci.appveyor.com/api/projects/status/n6f3d8ydtjm3eemu?svg=true)](https://ci.appveyor.com/project/JellyCZYT/pst-compressor)  
Compressing script for Chess-Challenge

- Made by Selenaut

## Function for using compressed PST Table
```
//enumeration to keep track externally of 
//which byte is for which scores
private enum ScoreType{Pawn, Knight, Bishop, Rook, Queen, King, MiddleKingScore, EndKingScore};

//Assuming you put your packed data table into a table called packedScores.
private int GetPieceBonusScore(ScoreType type, bool isWhite, int rank, int file)
{
    //Because the arrays are 8x4, we need to mirror across the files.
    if(file > 3) file = 7 - file;
    //Additionally, if we're checking black pieces, we need to flip the board vertically.
    if(!isWhite) rank = 7 - rank;
    int unpackedData = 0;
    ulong bytemask = 0xFF;
    //first we shift the mask to select the correct byte              ↓
    //We then bitwise-and it with PackedScores            ↓
    //We finally have to "un-shift" the resulting data to properly convert back       ↓
    //We convert the result to an sbyte, then to an int, to ensure it converts properly.
    unpackedData = (int)(sbyte)((packedScores[rank,file] & (bytemask << (int)type)) >> (int)type);
    //inverting eval scores for black pieces
    if(!isWhite) unpackedData *= -1;
    return unpackedData;
}
```
