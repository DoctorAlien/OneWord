function checkLength(msg,maxNum,remainingId) {//传入三个参数  msg:传入的信息   maxNum:设置最大的字数限制   remainingId:显示信息的标签id
    if (msg.value.length > maxNum){
        msg.value = msg.value.substring(0,maxNum);
    }
    var remainingNum = maxNum - msg.value.length;
    document.getElementById(remainingId).innerHTML = "还可以输入"+remainingNum.toString()+"字";
}