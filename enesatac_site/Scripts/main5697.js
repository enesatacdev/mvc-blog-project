/*====================================================
  TABLE OF CONTENT
  1. function declearetion
  2. Initialization
====================================================*/

/*===========================
 1. function declearetion
 ==========================*/
 "use strict";
var themeApp = {
	
	responsiveIframe: function() {
		jQuery('.post').fitVids();
	},
	mailchimp:function() {
		function IsEmail(email) {
			var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
			return regex.test(email);
		}
		if (typeof mailchimp_form_url !== 'undefined') {
			var form = jQuery('#mc-embedded-subscribe-form');
			form.attr("action", mailchimp_form_url);
			var message = jQuery('#message');
			var submit_button = jQuery('mc-embedded-subscribe');
			form.submit(function(e){
				e.preventDefault();
				jQuery('#mc-embedded-subscribe').attr('disabled','disabled');
				if(jQuery('#mce-EMAIL').val() != '' && IsEmail(jQuery('#mce-EMAIL').val())) {
					message.html('please wait...').fadeIn(1000);
					var url=form.attr('action');
					if(url=='' || url=='YOUR_MAILCHIMP_WEB_FORM_URL_HERE') {
						alert('Please config your mailchimp form url for this widget');
						return false;
					}
					else{
						url=url.replace('?u=', '/post-json?u=').concat('&c=?');
						console.log(url);
						var data = {};
						var dataArray = form.serializeArray();
						jQuery.each(dataArray, function (index, item) {
						data[item.name] = item.value;
						});
						jQuery.ajax({
							url: url,
							type: "POST",
							data: data,
							success: function(response, text){
								if (response.result === 'success') {
									message.html(response.result+ ": " + response.msg).delay(10000).fadeOut(500);
									jQuery('#mc-embedded-subscribe').removeAttr('disabled');
									jQuery('#mce-EMAIL').val('');
								}
								else{
									message.html(response.result+ ": " + response.msg).delay(10000).fadeOut(500);
									jQuery('#mc-embedded-subscribe').removeAttr('disabled');
									jQuery('#mce-EMAIL').focus().select();
								}
							},
							dataType: 'jsonp',
							error: function (response, text) {
								console.log('mailchimp ajax submit error: ' + text);
								jQuery('#mc-embedded-subscribe').removeAttr('disabled');
								jQuery('#mce-EMAIL').focus().select();
							}
						});
						return false;
					}
				}
				else {
					message.html('Please provide valid email').fadeIn(1000);
					jQuery('#mc-embedded-subscribe').removeAttr('disabled');
					jQuery('#mce-EMAIL').focus().select();
				}            
			});
		}
	},
	flickr:function() {
		if (typeof flickr_id !== 'undefined') {
			jQuery('.flkr-widget').jflickrfeed({
				limit: 8,
				qstrings: {
					id: flickr_id
				},
				itemTemplate: 
				'<li>' +
					'<a href="{{link}}" title="{{title}}" target="_blank"><img src="{{image_s}}" alt="{{title}}" /></a>' +
				'</li>'
			});
		}
	},
	magnificPopupInit: function() {
		jQuery('.magnific-popup-image').magnificPopup({
			delegate: 'a',
			type: 'image',
			gallery:{
				enabled:false
			},
			image:{
				titleSrc: 'data-caption'
			}
		});
		jQuery('.magnific-popup-gallery').magnificPopup({
			delegate: 'a',
			type: 'image',
			gallery:{
				enabled:true
			},
			image:{
				titleSrc: 'data-caption'
			}
		});
	},
	highlighter: function() {
		jQuery('pre code').each(function(i, block) {
		    hljs.highlightBlock(block);
		  });
	},
	backToTop: function() {
		jQuery(window).scroll(function(){
			if (jQuery(this).scrollTop() > 100) {
				jQuery('#back-to-top').fadeIn();
			} else {
				jQuery('#back-to-top').fadeOut();
			}
		});
		jQuery('#back-to-top').on('click', function(e){
			e.preventDefault();
			jQuery('html, body').animate({scrollTop : 0},1000);
			return false;
		});
	},
	init: function() {
		themeApp.responsiveIframe();
		themeApp.flickr();
		themeApp.highlighter();
		themeApp.mailchimp();
		themeApp.magnificPopupInit();
		themeApp.backToTop();
	}
}

/*===========================
2. Initialization
==========================*/
jQuery(document).ready(function(){
  themeApp.init();
});
jQuery(window).load(function() {
	jQuery('.flexslider').flexslider({
		controlNav: false,
		prevText: '<i class="fa fa-angle-left"></i>',
		nextText: '<i class="fa fa-angle-right"></i>',
		slideshowSpeed: '3000',
		pauseOnHover: true
	});
});

/*====================================================
	function for facebook status
====================================================*/
(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.2";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

$(document).ready(function () {

	var $slider = $(".slider"),
		$slideBGs = $(".slide__bg"),
		diff = 0,
		curSlide = 0,
		numOfSlides = $(".slide").length - 1,
		animating = false,
		animTime = 500,
		autoSlideTimeout,
		autoSlideDelay = 6000,
		$pagination = $(".slider-pagi");

	function createBullets() {
		for (var i = 0; i < numOfSlides + 1; i++) {
			var $li = $("<li class='slider-pagi__elem'></li>");
			$li.addClass("slider-pagi__elem-" + i).data("page", i);
			if (!i) $li.addClass("active");
			$pagination.append($li);
		}
	};

	createBullets();

	function manageControls() {
		$(".slider-control").removeClass("inactive");
		if (!curSlide) $(".slider-control.left").addClass("inactive");
		if (curSlide === numOfSlides) $(".slider-control.right").addClass("inactive");
	};

	function autoSlide() {
		autoSlideTimeout = setTimeout(function () {
			curSlide++;
			if (curSlide > numOfSlides) curSlide = 0;
			changeSlides();
		}, autoSlideDelay);
	};

	autoSlide();

	function changeSlides(instant) {
		if (!instant) {
			animating = true;
			manageControls();
			$slider.addClass("animating");
			$slider.css("top");
			$(".slide").removeClass("active");
			$(".slide-" + curSlide).addClass("active");
			setTimeout(function () {
				$slider.removeClass("animating");
				animating = false;
			}, animTime);
		}
		window.clearTimeout(autoSlideTimeout);
		$(".slider-pagi__elem").removeClass("active");
		$(".slider-pagi__elem-" + curSlide).addClass("active");
		$slider.css("transform", "translate3d(" + -curSlide * 100 + "%,0,0)");
		$slideBGs.css("transform", "translate3d(" + curSlide * 50 + "%,0,0)");
		diff = 0;
		autoSlide();
	}

	function navigateLeft() {
		if (animating) return;
		if (curSlide > 0) curSlide--;
		changeSlides();
	}

	function navigateRight() {
		if (animating) return;
		if (curSlide < numOfSlides) curSlide++;
		changeSlides();
	}

	$(document).on("mousedown touchstart", ".slider", function (e) {
		if (animating) return;
		window.clearTimeout(autoSlideTimeout);
		var startX = e.pageX || e.originalEvent.touches[0].pageX,
			winW = $(window).width();
		diff = 0;

		$(document).on("mousemove touchmove", function (e) {
			var x = e.pageX || e.originalEvent.touches[0].pageX;
			diff = (startX - x) / winW * 70;
			if ((!curSlide && diff < 0) || (curSlide === numOfSlides && diff > 0)) diff /= 2;
			$slider.css("transform", "translate3d(" + (-curSlide * 100 - diff) + "%,0,0)");
			$slideBGs.css("transform", "translate3d(" + (curSlide * 50 + diff / 2) + "%,0,0)");
		});
	});

	$(document).on("mouseup touchend", function (e) {
		$(document).off("mousemove touchmove");
		if (animating) return;
		if (!diff) {
			changeSlides(true);
			return;
		}
		if (diff > -8 && diff < 8) {
			changeSlides();
			return;
		}
		if (diff <= -8) {
			navigateLeft();
		}
		if (diff >= 8) {
			navigateRight();
		}
	});

	$(document).on("click", ".slider-control", function () {
		if ($(this).hasClass("left")) {
			navigateLeft();
		} else {
			navigateRight();
		}
	});

	$(document).on("click", ".slider-pagi__elem", function () {
		curSlide = $(this).data("page");
		changeSlides();
	});

});