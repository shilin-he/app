configs ={
  :git => {
    :provider => 'github',
    :user => 'aglcmarch2014',
    :remotes => %w/cmanners jreyes20 aglc-dennis mshogren edmikeca kanwu samankodithuwakku mhaagsma shilin-he/,
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
