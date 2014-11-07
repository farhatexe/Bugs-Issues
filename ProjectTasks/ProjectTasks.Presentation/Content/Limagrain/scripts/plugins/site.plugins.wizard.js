/// <reference path="../../../Metronic/metronic/assets/global/scripts/metronic.js" />
(function ($) {
    jQuery.fn.extend({
        formWizard: function () {
            if (!jQuery().bootstrapWizard) {
                return;
            }

            var form_wizard = $(this);
            
            var handleTitle = function (tab, navigation, index) {
                var total = navigation.find('li').length;
                var current = index + 1;
                // set wizard title
                $('.step-title', form_wizard).text(app.localization.Global.Wizard_StepTitle.format(index + 1, total));
                // set done steps
                jQuery('li', form_wizard).removeClass("done");


                var li_list = navigation.find('li');
                for (var i = 0; i < index; i++) {
                    jQuery(li_list[i]).addClass("done");
                }

                if (current == 1) {
                    form_wizard.find('.button-previous').hide();
                } else {
                    form_wizard.find('.button-previous').show();
                }

                if (current >= total) {
                    form_wizard.find('.button-next').hide();
                    form_wizard.find('.button-submit').show();
                } else {
                    form_wizard.find('.button-next').show();
                    form_wizard.find('.button-submit').hide();
                }
                Metronic.scrollTo(form_wizard.closest('.portlet'), -20);
            }

            return form_wizard.bootstrapWizard({
                'nextSelector': '.button-next',
                'previousSelector': '.button-previous',
                onNext: function (tab, navigation, index) {
                    form_wizard.trigger({ type: 'next', tab: tab, navigation: navigation, index: index });

                    form_wizard.find('input').addClass('ignore');
                    $('.tab-content .active input', form_wizard).removeClass('ignore');

                    form_wizard.find('input').removeClass('ignore');

                    handleTitle(tab, navigation, index);
                },
                onPrevious: function (tab, navigation, index) {
                    form_wizard.trigger({ type: 'previous', tab: tab, navigation: navigation, index: index });

                    handleTitle(tab, navigation, index);
                },
                onLast: function (tab, navigation, index) {
                    form_wizard.trigger({ type: 'last', tab: tab, navigation: navigation, index: index });
                },
                onFirst: function () {
                    form_wizard.trigger({ type: 'first', tab: tab, navigation: navigation, index: index });
                },
                onTabChange: function (tab, navigation, index, clickedIndex) {
                    form_wizard.trigger({ type: 'tabChange', tab: tab, navigation: navigation, index: index, clickedIndex: clickedIndex });
                },
                onTabClick: function (tab, navigation, index, clickedIndex) {
                    form_wizard.trigger({ type: 'tabClick', tab: tab, navigation: navigation, index: index, clickedIndex: clickedIndex });

                    handleTitle(tab, navigation, clickedIndex);
                },
                onTabShow: function (tab, navigation, index) {
                    form_wizard.trigger({ type: 'tabShow', tab: tab, navigation: navigation, index: index });

                    var total = navigation.find('li').length;
                    var current = index + 1;
                    var $percent = (current / total) * 100;
                    form_wizard.find('.progress-bar').css({
                        width: $percent + '%'
                    });
                }
            });
        }
    });
})(jQuery);