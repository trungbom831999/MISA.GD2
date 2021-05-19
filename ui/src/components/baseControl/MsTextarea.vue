<template>
  <div class="ms-component ms-con-textarea">
    <div v-if="label" class="ms-text-area-title-container">
      <div class="ms-text-area-title">
        {{ label }}
      </div>
      <div v-if="required" class="ms-input-title-require">&nbsp;*</div>
    </div>
    <span class="text-area--validate">
      <textarea
        class="ms-textarea"
        :class="{ 'grid-editor': gridEditor }"
        :rows="rows"
        v-bind="$attrs"
        v-bind:value="value"
        v-on:input="$emit('input', $event.target.value)"
        :maxlength="maxlength"
      ></textarea>
    </span>
  </div>
</template>

<script>
export default {
  props: {
    label: {
      type: String,
      default: "",
    },
    rows: {
      type: String,
      default: "",
    },
    gridEditor: {
      type: Boolean,
      default: false,
    },
    maxlength:{
      type: String,
      default: ""
    },
    required: {
      type: Boolean,
      default: false,
    },
    value: {},
  },
};
</script>

<style scoped>
textarea:not(:focus):hover {
  outline: 1px solid #e2e2e2 !important;
}

textarea:focus {
  border: 1px solid #2ca01c !important;
}

.ms-con-textarea {
  width: 100%;
  height: 100%;
  position: relative;
  display: flex;
  flex-direction: column;
}

.ms-con-textarea .ms-text-area-title-container {
  display: flex;
}

.ms-con-textarea .ms-text-area-title-container .ms-text-area-title {
  font-size: 12px;
  font-weight: 700;
  padding-bottom: 4px;
  white-space: nowrap;
}

.ms-con-textarea .text-area--validate {
  flex: 1;
}

.ms-con-textarea .ms-textarea {
  resize: none;
  border-radius: 3px;
  border: 1px solid #babec5;
  font-family: inherit;
  display: block;
  padding: 9px;
  color: #000;
  font-size: 13px;
  width: 100%;
  height: 100%;
}

textarea.ms-textarea {
  line-height: 1.6;
}

.ms-con-textarea .grid-editor {
  padding: 5px 10px 6px 10px;
  line-height: 20px;
  overflow: hidden;
}
</style>
