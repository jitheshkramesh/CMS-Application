 
	$(document).on("scroll", function() {  
		
	if($(document).scrollTop()>100) {
		
 $('.menus').addClass("bordertops");
	 
 
	 $('#float_arrow').css("display","block");	
  
	} else {
			 $('.menus').removeClass("bordertops");
   $('#float_arrow').css("display","none");
	}
		
 
	 
		
});
 
$(document).ready(function(){
	
$('#primary_nav_wrap ul a.levels1').hover(function() {
 
  $(this).removeClass("bgarrow");
 $(this).addClass("bgarrowwhite");
 
});
	$('#primary_nav_wrap ul a.levels1').mouseout(function() {
 
  $(this).removeClass("bgarrowwhite");
 $(this).addClass("bgarrow");
 
});
	
	$('#slider1_container  div#banner1').hover(function() {
 
	 $(this).show();
	  
});
		
	$('#slider1_container  div#banner2').hover(function() {
 
	 $(this).show();
	  
});
		
	$('#slider1_container  div#banner3').hover(function() {
 
	 $(this).show();
	  
});
	
});