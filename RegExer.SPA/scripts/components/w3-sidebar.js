define(['vue'], function (Vue) {
    'use strict'

    Vue.component('w3-sidebar', {

        template:
`<div class="w3-sidebar w3-animate-left w3-hide" :class="{ 'w3-show': isShown }" @mouseleave="isShown = false">
    <div class="w3-display-container">
        <button v-on:click="isShown = false" class="w3-button w3-right w3-red">&times;</button>
    </div>
    <div class="w3-container">
        <slot></slot>
    </div>
</div>`,

        data: function () {
            return {
                isShown: false
            }
        },

        props: {
            show: Boolean
        },

        watch: {
            show: function (value) {
                this.isShown = value;
            },
            isShown: function (value) {
                if (value == false) {
                    this.$emit('hidden');
                }
            }
        }
    });

});