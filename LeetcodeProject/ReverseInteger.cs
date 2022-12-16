namespace LeetcodeProject
{
    public class ReverseInteger
    {
        /// <summary>
        /// 7. Reverse Integer
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            // 這裡我採用 int 先轉成 string array，再用 Array.Reverse() 反轉的處理方式
            var intStr = x.ToString();

            // 如果 x 是負數，就先把「-」拿掉，先用純數字做轉換的處理
            if (x < 0) intStr = intStr.Substring(1, intStr.Length - 1);
            var strArr = intStr.ToCharArray();
            Array.Reverse(strArr);
            var resultInteger = 0;

            // 這裡使用 int.TryParse，如果一旦反轉後的 int 超過 MaxValue，這裡就會 false
            if (!int.TryParse(new string(strArr), out resultInteger)) resultInteger = 0;

            // 如果原本 x 是負數，再把「-」加回去
            if (x < 0) resultInteger = -resultInteger;
            return resultInteger;
        }
    }
}
