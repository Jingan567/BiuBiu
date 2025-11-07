using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

using Avalonia.Controls;
using Avalonia.Media;

namespace BiuBiu.ViewModels
{
    public partial class MessageViewModel : ViewModelBase
    {
        public string[] strings =
        {
            "今天过得怎么样？有没有好好照顾自己呀？", "降温了，记得多穿点衣服，别感冒了哦！", "早餐吃了吗？再忙也要记得按时吃饭呀～", "最近工作/学习累不累？别给自己太大压力啦！",
            "今天天气不错，出去走走晒晒太阳吧！", "看你最近总熬夜，这样对身体不好，早点休息呀！", "头疼好点了吗？要不要我帮你买点药？", "运动完记得拉伸，别让肌肉酸痛影响明天的状态！",
            "你胃不好，少吃点辣的，我陪你喝粥吧～", "最近流感严重，出门记得戴口罩，勤洗手哦！", "如果心情不好，随时找我聊天，我一直都在。", "别总把心事憋在心里，说出来会舒服很多。",
            "你已经很棒了，别太苛责自己，慢慢来就好。", "遇到困难别怕，我们一起想办法解决！", "你笑起来最好看了，多笑笑，别总皱眉头～", "下雨了，你带伞了吗？要不要我去接你？",
            "你手机快没电了，记得带充电宝，别失联呀！", "你喜欢的那家奶茶店出新口味了，要不要一起去试试？", "你书落在我这儿了，什么时候方便我拿给你？", "你总丢三落四，钥匙放我这儿一份吧！",
            "别灰心，失败是成功之母，下次一定行！", "你那么努力，结果一定会如你所愿的！", "相信自己，你比想象中更优秀！", "别怕犯错，大胆去做，我会在背后支持你！", "你坚持的样子真的很酷，继续加油！",
            "再熬夜就要变成熊猫眼啦，快睡吧！", "你再不吃早饭，胃就要‘抗议’啦！", "别总宅在家里，出去晒晒太阳，不然都要发霉了！", "你最近是不是又瘦了？是不是又偷偷减肥了？",
            "你再这么忙，我都快不认识你了，抽空陪陪我呗～", "生日快乐！愿你新的一岁，平安喜乐，万事胜意！", "情人节快乐！不管有没有对象，都要好好爱自己哦～", "教师节快乐！您辛苦了，感谢您一直以来的教导！",
            "母亲节/父亲节快乐！您永远是我最坚强的后盾！", "新年快乐！愿新的一年，我们都能奔赴在热爱里！", "夜深了，别刷手机了，早点睡，晚安～", "如果睡不着，我可以陪你聊聊天，直到你困了为止。",
            "你总说失眠，要不要试试我的‘独家助眠秘籍’？", "别想太多，好好睡一觉，明天又是新的一天！", "你梦里有我吗？没有的话，我现在去你梦里报道～", "咱俩谁跟谁呀，有困难直接说，别客气！",
            "你最近怎么都不找我玩了？是不是把我忘了？", "下次一起去旅行吧，我负责拍照，你负责笑！", "你推荐的剧/歌/书我都看了/听了/读了，真的超棒！",
            "你永远是我最好的朋友，无论发生什么，我都会站在你这边！", "妈/爸，您别总舍不得吃好的，身体最重要！", "你总说我不听话，其实我都记着您的唠叨呢～", "家里一切都好，您在外别太辛苦，注意身体！",
            "你总担心我，其实我已经长大了，能照顾好自己了！", "无论我走多远，家永远是我最温暖的港湾！"
        };
        public MessageViewModel()
        {
            color = new SolidColorBrush(GetRandomLightColor());
            messageText = strings[new Random().Next(strings.Length)];
        }

        [ObservableProperty]
        public SolidColorBrush color = new SolidColorBrush(Colors.Transparent); // 初始化为透明色

        [ObservableProperty]
        public string messageText  = string.Empty;

        /// <summary>
        /// 随机生成一个浅色（亮度 > 70%）
        /// </summary>
        private Color GetRandomLightColor()
        {
            Random random = new Random();

            // 生成 HSB 颜色空间中的随机值（浅色需高亮度）
            double hue = random.NextDouble() * 360;        // 色相 0-360
            double saturation = random.NextDouble() * 0.5;  // 饱和度 0-0.5（降低饱和度避免刺眼）
            double brightness = 0.7 + random.NextDouble() * 0.3; // 亮度 0.7-1.0（确保浅色）


            return HsbToRgb(hue, saturation, brightness);
        }

        /// <summary>
        /// HSB 转 RGB 辅助方法
        /// </summary>
        private Color HsbToRgb(double h, double s, double b)
        {
            h = h % 360;
            s = Math.Clamp(s, 0, 1);
            b = Math.Clamp(b, 0, 1);

            double c = b * s;
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = b - c;

            double r, g, bl;
            if (h >= 0 && h < 60) { r = c; g = x; bl = 0; }
            else if (h >= 60 && h < 120) { r = x; g = c; bl = 0; }
            else if (h >= 120 && h < 180) { r = 0; g = c; bl = x; }
            else if (h >= 180 && h < 240) { r = 0; g = x; bl = c; }
            else if (h >= 240 && h < 300) { r = x; g = 0; bl = c; }
            else { r = c; g = 0; bl = x; }

            return new Color(10,
                 (byte)((r + m) * 255),
                 (byte)((g + m) * 255),
                 (byte)((bl + m) * 255)
             );
        }

        [RelayCommand(CanExecute = "CanClose")]
        public void Close(UserControl t)
        {
            var control = t as UserControl;
            if (control != null)
            {
                // Add your logic here if needed  
            }
        }
        
        private bool CanClose(UserControl t)
        {
            return true;
        }
    }
}

