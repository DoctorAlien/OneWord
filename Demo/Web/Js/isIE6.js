function isIE6(dely_time,right_url,wrong_url){
    //请勿修改以下内容
    var browser=navigator.appName;//获得浏览器信息
    var b_version=navigator.appVersion;//获得浏览器版本号
    var version=parseFloat(b_version);
    //判断是不是IE6
    if((browser=="Netscape"||browser=="Microsoft Internet Explorer")&&(version>4)){
        window.location.href=right_url;//不为IE6，跳转至正确的页面
    }else{
        //是IE6，先提示后跳转
        document.write("<div style='font-size:22px;width: 98%;height:80px;line-height: 80px;border: solid 1px lightblue;top:35%;position: absolute;margin:0 auto;text-align: center;box-shadow: 5px 5px 5px #CCCCCC;'>请使用IE6以上的版本, <span id='time' style='color:red;font-weight: bolder'>"+dely_time+"</span> 秒后进行跳转</div>");
        delayURL(wrong_url);
    }
}
//倒计时
function delayURL(url) {
    var delay=document.getElementById("time").innerHTML;
    if(delay>0){
        delay--;
        document.getElementById("time").innerHTML=delay;
    }else{
        window.top.location.href=url;
    }
    setTimeout("delayURL('" + url + "')", 1000);//此处1000毫秒即每一秒跳转一次
}