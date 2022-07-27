function ClickLoginUC($)
{
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  

	var template = '<meta name="viewport" content="width=device-width, initial-scale=1"><link rel="stylesheet" href="{{rutakb}}LibLogin/css/main.css"><link rel="stylesheet" href="{{rutakb}}LibLogin/fonts/font-awesome-4.7.0/css/font-awesome.min.css"><link rel="stylesheet" href="{{rutakb}}LibLogin/vendor/animate/animate.css"><link rel="stylesheet" href="{{rutakb}}LibLogin/vendor/css-hamburgers/hamburgers.min.css"><link rel="stylesheet" href="{{rutakb}}LibLogin/vendor/select2/select2.min.css"><link rel="stylesheet" href="{{rutakb}}LibLogin/css/util.css"><link rel="stylesheet" href="{{rutakb}}LibLogin/css/main.css"><div class="limiter">		<div class="container-login100">			<div class="wrap-login100">				<div class="login100-pic js-tilt" data-tilt>					<img src="{{image}}" alt="IMG">				</div>				<div class="login100-form validate-form">					<span class="login100-form-title">						{{titulo}}					</span>					<div class="wrap-input100 validate-input" data-validate = "{{erroremail}}">						{{inputusuario}}							<div data-slot="addusuarioin2" data-parent="{{ContainerName}}"></div>						<span class="focus-input100"></span>						<span class="symbol-input100">							<i class="fa fa-envelope" aria-hidden="true"></i>						</span>					</div>					<div class="wrap-input100 validate-input" data-validate = "{{errorpassword}}">						{{inputpassword}}							<div data-slot="addpasswordin2" data-parent="{{ContainerName}}"></div>						<span class="focus-input100"></span>						<span class="symbol-input100">							<i class="fa fa-lock" aria-hidden="true"></i>						</span>					</div>					<div class="text-center p-t-8 {{alertamsg}}">						<a class="txtred" href="#">							{{textomsgalert}}							<i class="fa fa-exclamation-triangle m-l-5" aria-hidden="true"></i>						</a>					</div>					<div class="container-login100-form-btn">						<div class="login100-form-btn"  data-event="click"  id="BTNLOGIN">							{{textbutton}}						</div>					</div>					<div class="text-center p-t-12">						<span class="txt1">							{{forgot1}}						</span>						<a class="txt2" href="{{linkforgot}}">							{{forgot2}}						</a>					</div>					<div class="text-center p-t-13">						<a class="txt2" href="{{linkcreateaccount}}">							{{createaccount}}							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>						</a>					</div>				</div>			</div>		</div>	</div>	<script > $(document).ready(function(){$(\'.js-tilt\').tilt({scale: 1.1}) });</script>	<script type="text/javascript" src="{{rutakb}}LibLogin/vendor/jquery/jquery-3.2.1.min.js" data-gx-external-script=""></script>	<script type="text/javascript" src="{{rutakb}}LibLogin/vendor/bootstrap/js/popper.js" data-gx-external-script=""></script>	<script type="text/javascript" src="{{rutakb}}LibLogin/vendor/select2/select2.min.js" data-gx-external-script=""></script>	<script type="text/javascript" src="{{rutakb}}LibLogin/vendor/tilt/tilt.jquery.min.js" data-gx-external-script=""></script>	<script type="text/javascript">$(document).ready(function(){    "use strict";    $(\'body\').on(\'keydown\', \'#v{{varusuario}}\', function(e) {        if (e.which == 9) {            e.preventDefault();            var input = $(\'#v{{varusuario}}\');            var check = true;            for(var i=0; i<input.length; i++) {                if(validate(input[i]) == false){                    showValidate(input[i]);                    check=false;                }            }            return check;        }    });    $(\'body\').on(\'keydown\', \'#v{{varpassword}}\', function(e) {        if (e.which == 9) {            e.preventDefault();            var input = $(\'#v{{varpassword}}\');            var check = true;            for(var i=0; i<input.length; i++) {                if(validate(input[i]) == false){                    showValidate(input[i]);                    check=false;                }            }            return check;        }    });    $(\'.validate-form .input100\').each(function(){        $(this).focus(function(){           hideValidate(this);        });    });		$("#BTNLOGIN").click(function(){       $(\'.js-tilt\').tilt({scale: 1.1});    });	    function validate (input) {        if($(input).attr(\'type\') == \'email\' || $(input).attr(\'name\') == \'email\') {            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {                return false;            }        }        else {            if($(input).val().trim() == \'\'){                return false;            }        }    }    function showValidate(input) {        var thisAlert = $(input).parent().parent().parent().parent().parent().parent().parent();        $(thisAlert).addClass(\'alert-validate\');    }    function hideValidate(input) {        var thisAlert = $(input).parent().parent().parent().parent().parent().parent().parent();		        $(thisAlert).removeClass(\'alert-validate\');    } });</script>';
	Mustache.parse(template);
	var _iOnclick = 0; 
	var $container;
	this.show = function()
	{
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnclick = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='click']")
				.on('click', this.onclickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			this.toggleVisibility();

			// Raise after show scripts

	}

	this.Scripts = [  ];



		this.onclickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
				 
			}

			if (this.click) {
				this.click();
			}
		} 

	this.toggleVisibility = function () {
		if (this.Visible) {
			$container.show();
		}
		else {
			$container.hide();
		}
	};

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}