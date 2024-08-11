using UnityEngine;
using YGOSharp.OCGWrapper.Enums;

public class VoiceMap : MonoBehaviour
{
    public static int Map(string character, string type, int card, bool firstOnField = true, uint location = (uint)CardLocation.Onfield, int chain = 1)
    {
        switch (character)
        {
            case "V0501":
                return V0501(type, card, firstOnField, location, chain);
        }
        return -10;
    }
    //effect activate                   08
    //monster effect activate    09
    //summon                           13
    //attack                               19


    static int V0501(string type, int card, bool firstOnField = true,uint location = (uint)CardLocation.Onfield, int chain = 1)
    {
        switch (type)
        {
            case "summon":
                switch (card)
                {
                    case 16178681:
                        return 0;
                    case 53025096:
                        return 1;
                    case 19221310:
                        return 2;
                    case 21770839:
                        return 3;
                    case 93149655:
                        return 4;
                    case 21250202:
                        return 5;
                    case 67754901:
                        return 6;
                    case 83347294:
                        return 7;
                    case 72378329:
                        return 8;
                    case 88305705:
                        return 9;
                    case 1516510:
                        return 10;
                    case 82044279:
                        return 11;
                    case 41209827:
                        return 12;
                    case 16195942:
                        return 13;
                    case 1621413:
                        return 14;
                    case 86238081:
                        return 15;
                    case 45627618:
                        return 16;
                    case 45014450:
                        return 17;
                    case 58074177:
                        return 18;
                    case 70335319:
                        return 19;
                    case 16306932:
                        return 20;
                    case 42562690:
                        return 21;
                    case 79967395:
                        return 22;
                    case 91449532:
                        return 23;
                    case 82224646:
                        return 24;
                    case 46136942:
                            return 25;
                    case 86157908:
                        return 26;
                    case 78835747:
                        return 27;
                    case 26270847:
                        return 28;
                    case 15978426:
                        return 29;
                    case 15452043:
                        return 30;
                    case 17857780:
                        return 31;
                    case 41440148:
                        return 32;
                    case 91584698:
                        return 33;
                    case 42002073:
                        return 34;
                    case 43241495:
                        return 35;
                    case 9106362:
                        return 36;
                    case 69211541:
                        return 37;
                    case 4239451:
                        return 38;
                    case 96606246:
                        return 39;
                    case 44364077:
                        return 40;
                    case 17330916:
                        return 41;
                    case 44481227:
                        return 42;
                    case 73130445:
                        return 43;
                    case 9000988:
                        return 44;
                    case 59123194:
                        return 45;
                    case 33656832:
                        return 46;
                    case 45667991:
                        return 47;
                    case 80335817:
                        return 48;
                    case 20409757:
                        return 49;
                    case 94415058:
                        return 50;
                    case 71692913:
                        return 51;
                    case 17086528:
                        return 52;
                    case 54941203:
                        return 53;
                    case 80896940:
                        return 54;
                    case 18027139:
                        return 55;
                    case 11050416:
                        return 55;
                }
                break;
            case "attack":
                switch (card)
                {
                    case 16178681:
                        return Random.Range(0, 2);
                }
                return V0501("summon", card) +1;
            case "summonline":
                switch (card)
                {
                    case 16178681:
                        return 0;
                    case 53025096:
                        return 1;
                    case 19221310:
                        return 2;
                    case 21770839:
                        return 3;
                    case 83347294:
                        return 4;
                    case 72378329:
                        return 5;
                    case 88305705:
                        return 6;
                    case 1516510:
                        return 7;
                    case 82044279:
                        return 8;
                    case 41209827:
                        return 9;
                    case 16195942:
                        return 10;
                    case 1621413:
                        return 11;
                    case 86238081:
                        return 12;
                    case 45627618:
                        return 13;
                    case 45014450:
                        return 14;
                    case 58074177:
                        return 15;
                    case 16306932:
                        return 16;
                    case 59123194:
                        return 17;
                    case 80896940:
                        return 18;
                }
                break;
            case "activate":
                switch (card)
                {
                    case 71705144:
                        return 0;
                    case 37803970:
                        return 1;
                    case 62161698:
                        return 2;
                    case 46066477:
                        return 3;
                    case 19162134:
                        return 4;
                    case 18027138:
                        return 5;
                    case 14816688:
                        return 6;
                    case 47870325:
                        if(firstOnField)
                            return 7;
                        else
                            return 8;
                    case 35259350:
                        return 9;
                    case 2099841:
                        return 10;
                    case 37469904:
                        return 11;
                    case 41367003:
                        return 12;
                    case 83461421:
                        return 13;
                    case 18752707:
                        return 14;
                    case 5972394:
                        return 15;
                    case 78574395:
                        if(firstOnField)
                            return 16;
                        else
                            return 17;
                    case 34884015:
                        if(firstOnField)
                            return 18;
                        else
                            return 19;
                    case 11050415:
                        return 20;
                    case 82768499:
                        return 21;
                    case 11481610:
                        return 22;
                    case 55553602:
                        if (firstOnField)
                            return 23;
                        else
                            return 24;
                    case 27813661:
                        if (firstOnField)
                            return 25;
                        else
                            return 26;
                    case 22765132:
                        return 27;
                    case 36415522:
                        if (firstOnField)
                            return 28;
                        else
                            return 29;
                    case 5672432:
                        return 30;
                    case 78184733:
                        return 31;
                    case 16720314:
                        return 32;
                    case 95254840:
                        return 33;
                    case 84274024:
                        if (firstOnField)
                            return 34;
                        else
                            return 35;
                    case 9852718:
                        return 36;
                    case 58169731:
                        return 37;
                    case 92958307:
                        return 38;
                    case 16178681:
                        return 39;
                    case 21770839:
                        return 40;
                    case 93149655:
                        return 41;
                    case 21250202:
                        return 42;
                    case 67754901:
                        return 43;
                    case 86238081:
                        return 44;
                    case 45627618:
                        return 45;
                    case 45014450:
                        return 46;
                    case 58074177:
                        return 47;
                    case 70335319:
                        return 48;
                    case 16306932:
                        return 49;
                    case 82224646:
                        return 50;
                    case 46136942:
                        return 51;
                    case 86157908:
                        return 52;
                    case 91584698:
                        return 53;
                    case 42002073:
                        return 54;
                    case 43241495:
                        return 55;
                    case 9106362:
                        return 56;
                    case 69211541:
                        return 57;
                    case 4239451:
                        return 58;
                    case 17330916:
                        return 59;
                    case 44481227:
                        return 60;
                    case 73130445:
                        return 61;
                    case 9000988:
                        return 62;
                    case 33656832:
                        return 63;
                    case 45667991:
                        return 64;
                    case 80335817:
                        return 65;
                    case 71692913:
                        return 66;
                    case 17086528:
                        return 67;
                    case 80896940:
                        return 68;
                }
                break;
            case "activateM":
                switch (card)
                {
                    case 53025096:
                        return 0;
                    case 19221310:
                        if ((location & (uint)CardLocation.Hand) > 0)
                            return 101;
                        else
                            return 1;
                    case 21770839:
                        if((location & (uint)CardLocation.Hand) > 0)
                            return 2;
                        else
                            return 3;
                    case 93149655:
                        return 4;
                    case 21250202:
                        return 5;
                    case 67754901:
                        return 6;
                    case 83347294:
                        if ((location & (uint)CardLocation.Hand) > 0)
                            return 107;
                        else 
                            return 7;
                    case 72378329:
                        return 8;
                    case 88305705:
                        return 9;
                    case 82044279:
                        return 10;
                    case 41209827:
                        return 11;
                    case 16195942:
                        return 12;
                    case 1621413:
                        if(chain == 1)
                            return 13;
                        else
                            return 14;
                    case 86238081:
                        return 15;
                    case 45627618:
                        if((location& (uint)CardLocation.MonsterZone) > 0)
                            return 16;
                        else
                            return 17;
                    case 45014450:
                        return 18;
                    case 58074177:
                        return 19;
                    case 70335319:
                        if(chain == 1)
                            return 20;
                        else
                            return 21;
                    case 16306932:
                        if ((location & (uint)CardLocation.Hand) > 0)
                            return 122;
                        else
                            return 22;
                    case 42562690:
                        return 23;
                    case 79967395:
                        return 24;
                    case 91449532:
                        return 25;
                    case 82224646:
                        return 26;
                    case 46136942:
                        if ((location & (uint)CardLocation.Hand) > 0)
                            return 127;
                        else
                            return 27;
                    case 86157908:
                        return 28;
                    case 78835747:
                        return 29;
                    case 26270847:
                        return 30;
                    case 15978426:
                        return 31;
                    case 15452043:
                        return 32;
                    case 17857780:
                        return 33;
                    case 41440148:
                        return 34;
                    case 91584698:
                        return 35;
                    case 42002073:
                        return 36;
                    case 43241495:
                        return 37;
                    case 9106362:
                        return 38;
                    case 69211541:
                        return 39;
                    case 4239451:
                        return 40;
                    case 96606246:
                        return 41;
                    case 44364077:
                        return 42;
                    case 17330916:
                        return 143;
                    case 44481227:
                        return 44;
                    case 73130445:
                        return 45;
                    case 9000988:
                        return 46;
                    case 59123194:
                        return 47;
                    case 33656832:
                        if ((location & (uint)CardLocation.Hand) > 0)
                            return 148;
                        else
                            return 48;
                    case 45667991:
                        return 49;
                    case 80335817:
                        return 50;
                    case 94415058:
                        return 51;
                    case 71692913:
                        return 52;
                    case 17086528:
                        return 53;
                    case 54941203:
                        if ((location & (uint)CardLocation.Hand) > 0)
                            return 154;
                        else
                            return 54;
                    case 80896940:
                        return 55;
                }
                break;
        }
        return -10;
    }


    //    switch (card)
    //{
    //    case :
    //        return 0;
    //    case :
    //        return 1;
    //    case :
    //        return 2;
    //    case :
    //        return 3;
    //    case :
    //        return 4;
    //    case :
    //        return 5;
    //    case :
    //        return 6;
    //    case :
    //        return 7;
    //    case :
    //        return 8;
    //    case :
    //        return 9;
    //    case :
    //        return 10;
    //    case :
    //        return 11;
    //    case :
    //        return 12;
    //    case :
    //        return 13;
    //    case :
    //        return 14;
    //    case :
    //        return 15;
    //    case :
    //        return 16;
    //    case :
    //        return 17;
    //    case :
    //        return 18;
    //    case :
    //        return 19;
    //    case :
    //        return 20;
    //    case :
    //        return 21;
    //    case :
    //        return 22;
    //    case :
    //        return 23;
    //    case :
    //        return 24;
    //    case :
    //        return 25;
    //    case :
    //        return 26;
    //    case :
    //        return 27;
    //    case :
    //        return 28;
    //    case :
    //        return 29;
    //    case :
    //        return 30;
    //    case :
    //        return 31;
    //    case :
    //        return 32;
    //    case :
    //        return 33;
    //    case :
    //        return 34;
    //    case :
    //        return 35;
    //    case :
    //        return 36;
    //    case :
    //        return 37;
    //    case :
    //        return 38;
    //    case :
    //        return 39;
    //    case :
    //        return 40;
    //    case :
    //        return 41;
    //    case :
    //        return 42;
    //    case :
    //        return 43;
    //    case :
    //        return 44;
    //    case :
    //        return 45;
    //    case :
    //        return 46;
    //    case :
    //        return 47;
    //    case :
    //        return 48;
    //    case :
    //        return 49;
    //    case :
    //        return 50;
    //    case :
    //        return 51;
    //    case :
    //        return 52;
    //    case :
    //        return 53;
    //    case :
    //        return 54;
    //    case :
    //        return 55;
    //    case :
    //        return 56;
    //    case :
    //        return 57;
    //    case :
    //        return 58;
    //    case :
    //        return 59;
    //    case :
    //        return 60;
    //    case :
    //        return 61;
    //    case :
    //        return 62;
    //    case :
    //        return 63;
    //    case :
    //        return 64;
    //    case :
    //        return 65;
    //    case :
    //        return 66;
    //    case :
    //        return 67;
    //    case :
    //        return 68;
    //    case :
    //        return 69;
    //    case :
    //        return 70;
    //    case :
    //        return 71;
    //    case :
    //        return 72;
    //    case :
    //        return 73;
    //    case :
    //        return 74;
    //    case :
    //        return 75;
    //    case :
    //        return 76;
    //    case :
    //        return 77;
    //    case :
    //        return 78;
    //    case :
    //        return 79;
    //    case :
    //        return 80;
    //    case :
    //        return 81;
    //    case :
    //        return 82;
    //    case :
    //        return 83;
    //    case :
    //        return 84;
    //    case :
    //        return 85;
    //    case :
    //        return 86;
    //    case :
    //        return 87;
    //    case :
    //        return 88;
    //    case :
    //        return 89;
    //    case :
    //        return 90;
    //    case :
    //        return 91;
    //    case :
    //        return 92;
    //    case :
    //        return 93;
    //    case :
    //        return 94;
    //    case :
    //        return 95;
    //    case :
    //        return 96;
    //    case :
    //        return 97;
    //    case :
    //        return 98;
    //    case :
    //        return 99;
    //}

}
