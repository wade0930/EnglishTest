using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork
{
    public partial class PresentationModel
    {
        private bool _isNextEnable = false;
        private bool _isStartEnable = true;
        private bool _stop = false;
        private bool _fill = true;
        private bool _multiple = false;
        private bool _judge = false;
        private bool _last = false;
        private bool _initial = true;

        // 回傳stop的bool值
        public bool IsStopEnable()
        {
            return _stop;
        }

        //回傳Next按鈕的布林值
        public bool IsNextEnable()
        {
            return _isNextEnable;
        }

        //回傳Start按鈕的布林值
        public bool IsStartEnable()
        {
            return _isStartEnable;
        }

        //回傳初始化
        public bool IsBegin()
        {
            return _initial;
        }

        //回傳last
        public bool IsLast()
        {
            return _last;
        }

        //回傳填充題的布林值
        public bool IsGetFill()
        {
            return _fill;
        }

        //回傳選擇題的布林值
        public bool IsGetMultiple()
        {
            return _multiple;
        }

        //設定開始各個按鍵的bool
        public void SetStart()
        {
            _isStartEnable = false;
            _initial = false;
            _isNextEnable = true;
            _stop = true;
        }

        //設定結束的bool
        public void SetEnd(bool judge)
        {
            if (judge)
            {
                _isStartEnable = true;
                _isNextEnable = false;
                _initial = true;
                _stop = false;
            }
        }

        //回傳時間的bool
        public bool IsTime()
        {
            return _time.Enabled;
        }

        //Unittest
        public void Set(bool enable)
        {
            _time.Enabled = enable;
        }
    }
}