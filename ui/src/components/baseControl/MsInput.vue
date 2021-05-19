<template>
  <div class="ms-input ms-editor">
    <div v-if="label" class="flex">
      <div class="ms-input-title">
        <div class="ms-input-title-label">{{ label }}</div>
      </div>
      <div v-if="required" class="ms-input-title-require">&nbsp;*</div>
    </div>

    <div class="ms-component ms-con-input-label ms-input style-label">
      <div class="ms-con-input">
        <input
          ref="input"
          v-bind="$attrs"
          v-bind:value="value"
          v-on:input="$emit('input', $event.target.value)"
          type="text"
          class="ms-input--input normal ms-input-normal"
          :style="[textRight ? { 'text-align': 'right' } : '']"
        />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    label: {
      type: String,
      default: "",
    },
    required: {
      type: Boolean,
      default: false,
    },
    textRight: {
      type: Boolean,
      default: false,
    },
    value: {},
  },
  methods: {
    focusInput() {
      console.log(this.$refs.input);
      this.$refs.input.focus();
      // return this.$refs.msInput;
    },
  },
};
</script>

<style scoped>
input:not(:focus):hover {
  outline: 1px solid #e2e2e2 !important;
}

input:focus {
  border: 1px solid #2ca01c !important;
}

.ms-input {
  color: #111;
  width: 100%;
}

.ms-input .ms-input-title {
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 4px;
  white-space: nowrap;
}

.ms-input .ms-input-title-label {
  height: 100%;
}

.ms-input .ms-input-title-require {
  color: red;
  margin-left: 4px;
}

.ms-input .ms-con-input-label {
  position: relative;
  width: 100%;
}

.style-label {
  color: #111;
}

.ms-input .ms-con-input-label .ms-con-input {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  position: relative;
  justify-content: center;
  width: 100%;
}

.ms-input-normal {
  width: 100%;
  height: 100%;
  background-color: #fff;
}

.ms-input .ms-input--input.normal {
  padding: 6px 10px;
}

.ms-input .ms-input--input {
  font-size: 13px;
  height: 32px;
  color: inherit;
  position: relative;
  padding: 6px 10px;
  border-radius: 2px;
  border: 1px solid #babec5;
  box-sizing: border-box;
  width: 100%;
}
</style>
