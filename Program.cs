using System;

sbyte[,] pawnScores = 
{
    { 1,  1,  1,  1},
    {10, 10, 20, 30},
    {50, 50, 50, 50},
    { 5,  5, 10, 25},
    { 1,  1,  1, 20},
    { 5, -5,-10,  1},
    { 5, 10, 10,-20},
    { 1,  1,  1,  1}
};

sbyte[,] knightScores =
{
    {-50,-40,-30,-30},
    {-40,-20,  1,  1},
    {-30,  1, 10, 15},
    {-30,  5, 15, 20},
    {-30,  1, 15, 20},
    {-30,  5, 10, 15},
    {-40,-20,  1,  5},
    {-50,-40,-30,-30}
};

sbyte[,] bishopScores =
{
    {-20,-10,-10,-10},
    {-10,  1,  1,  1},
    {-10,  1,  5, 10},
    {-10,  5,  5, 10},
    {-10,  1, 10, 10},
    {-10, 10, 10, 10},
    {-10,  5,  1,  1},
    {-20,-10,-10,-10}
};

sbyte[,] rookScores =
{
    { 1,  1,  1,  1},
    { 5, 10, 10, 10},
    {-5,  1,  1,  1},
    {-5,  1,  1,  1},
    {-5,  1,  1,  1},
    {-5,  1,  1,  1},
    {-5,  1,  1,  1},
    { 1,  1,  1,  5}
};

sbyte[,] queenScores =
{
    {-20,-10,-10, -5},
    {-10,  1,  1,  1},
    {-10,  1,  5,  5},
    { -5,  1,  5,  5},
    {  1,  1,  5,  5},
    {-10,  5,  5,  5},
    {-10,  1,  5,  1},
    {-20,-10,-10, -5}
};

sbyte[,] kingScores =
{
    {-30,-40,-40,-50},
    {-30,-40,-40,-50},
    {-30,-40,-40,-50},
    {-30,-40,-40,-50},
    {-20,-30,-30,-40},
    {-10,-20,-20,-20},
    { 20, 20,  1,  1},
    { 20, 30, 10,  1}
};

sbyte[,] MiddleKingScores =
{
    {-30,-40,-40,-50},
    {-30,-40,-40,-50},
    {-30,-40,-40,-50},
    {-30,-40,-40,-50},
    {-20,-30,-30,-40},
    {-10,-20,-20,-20},
    { 20, 20,  1,  1},
    { 20, 30, 10,  1}
};

sbyte[,] EndKingScores =
{
    {-50,-40,-30,-20},
    {-30,-20,-10,  1},
    {-30,-10, 20, 30},
    {-30,-10, 30, 40},
    {-30,-10, 30, 40},
    {-30,-10, 20, 30},
    {-30,-30,  1,  1},
    {-50,-30,-30,-30}
};

void PackScoreData()
{
    //Add boards from "index" 0 upwards. Here, the pawn board is "index" 0.
    //That means it will occupy the least significant byte in the packed data.
    List<sbyte[,]> allScores = new();
    allScores.Add(pawnScores);
    allScores.Add(knightScores);
    allScores.Add(bishopScores);
    allScores.Add(rookScores);
    allScores.Add(queenScores);
    allScores.Add(kingScores);
    allScores.Add(MiddleKingScores);
    allScores.Add(EndKingScores);


    ulong[,] packedData = new ulong[8,4];
    for(int rank = 0; rank < 8; rank++)
    {
        for(int file = 0; file < 4; file++)
        {
            for(int set = 0; set < 8; set++)
            {
                //This is slightly inefficient but you only need to run this code once so it's fine
                sbyte[,] thisSet = allScores[set];
                //You could argue this should be |= but either operator works since no two digits overlap.
                packedData[rank,file] += ((ulong)thisSet[rank,file]) << (8 * set);
            }
        }
        Console.WriteLine("{{0x{0,16:X}, 0x{1,16:X}, 0x{2,16:X}, 0x{3,16:X}}},", packedData[rank,0], packedData[rank,1], packedData[rank,2], packedData[rank,3]);
    }
}

PackScoreData();
