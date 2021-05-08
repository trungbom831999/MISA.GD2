<template>
  <label for="" class="ms-component con-ms-checkbox" @click="changeInputCheckbox()">
    <input v-bind="$attrs"
        v-bind:value="value"
        v-on:input="$emit('input', isChecked)"
         type="checkbox" class="ms-checkbox--input" />
    <span :class="[isChecked ? 'ms-checkbox-border-isChecked-true' : 'ms-checkbox-border-isChecked-false']"
      class="ms-checkbox-border-disabled-false checkbox_x ms-checkbox"
    >
      <span
        class="ms-checkbox-inner ms-checkbox-check-disabled-false ms-checkbox--check"
      >
        <div v-if="isChecked" class="mi mi-16 mi-checkbox-active"></div>
      </span>
    </span>

    <span v-if="label" class="con-slot-label">
      <p>{{label}}</p>
    </span>
  </label>
</template>

<style scoped>
.con-ms-checkbox {
  justify-content: flex-start;
  position: relative;
  display: flex;
  align-items: center;
  cursor: pointer;
}

.ms-checkbox--input {
    position: absolute;
    width: 100%;
    height: 100%;
    opacity: 0;
    z-index: 200;
    cursor: pointer;
}

.ms-checkbox--input:focus+.ms-checkbox:before {
    content: "";
    height: 22px;
    width: 22px;
    position: absolute;
    border: 1px solid #a4dfff;
    display: block;
    border-radius: 2px;
}

.ms-checkbox {
  top: 0;
  left: 0;
  transition: all 0.2s ease;
  transform: rotate(-90deg);
  cursor: pointer;
  position: relative;
  display: block;
  width: 18px;
  height: 18px;
  border-radius: 2px;
  display: flex;
  align-items: center;
  justify-content: center;
  box-sizing: border-box;
  border: 1px solid #afafaf;
  background: #fff;
}

.ms-checkbox--input:isChecked + .ms-checkbox {
  transform: rotate(0deg);
}

.ms-checkbox-border-isChecked-true {
  border: 1px solid #2ca01c;
  transform: rotate(0deg);
}

.ms-checkbox-inner {
  width: inherit;
  height: inherit;
}

.con-slot-label {
  white-space: nowrap;
  padding-left: 10px;
  font-size: 13px;
}

.con-slot-label p{
  height: 100%;
}
</style>
<script>
export default {
  props:{
    label:{
      type: String,
      default: ""
    },
    value:{}
  },
  data() {
    return {
      isChecked: this.value,
    };
  },
  methods:{
      show(){
          console.log(this.isChecked);
      },

      changeInputCheckbox(){
          if(this.isChecked == true){
              this.isChecked = false;
          }
          else{
              this.isChecked = true;
          }
          console.log(this.isChecked);
      }
  }
};
</script>